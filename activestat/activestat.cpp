#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <mutex>          
#include <unordered_map>
#include <winsock2.h>
#include <psapi.h>
#include <shlwapi.h>

#include <algorithm>
#include <cctype>
#include <locale>

#include <conio.h>

#include <ctime>

#include <windows.h>
#include <stdio.h>
#include <netfw.h>

#include "windivert.h"

#pragma comment( lib, "ole32.lib" )

using namespace std;

#define ntohs(x)            WinDivertHelperNtohs(x)
#define ntohl(x)            WinDivertHelperNtohl(x)
#define htons(x)            WinDivertHelperHtons(x)
#define htonl(x)            WinDivertHelperHtonl(x)

vector<string> split_args(string str)
{
	vector<string> tmp;
	string arg = "";
	for (string::size_type i = 0; i < str.size(); i++)
	{
		char c = str[i];
		if (c == '#')
		{
			break;
		}
		else if (isspace(c))
		{
			if (arg.compare("") != 0)
			{
				tmp.push_back(arg);
				arg = "";
			}
		}
		else
		{
			arg.push_back(c);
		}
	}
	if (arg.compare("") != 0)
	{
		tmp.push_back(arg);
		arg = "";
	}
	return tmp;
}

vector<string> split(string str, char del, bool skip_empty = false)
{
	vector<string> tmp;
	string arg = "";
	for (string::size_type i = 0; i < str.size(); i++)
	{
		char c = str[i];
		if (c == del)
		{
			if (!skip_empty || arg.compare("") != 0)
			{
				tmp.push_back(arg);
				arg = "";
			}
		}
		else
		{
			arg.push_back(c);
		}
	}
	if (!skip_empty || arg.compare("") != 0)
	{
		tmp.push_back(arg);
		arg = "";
	}
	return tmp;
}

string format(ULONG num)
{
	if (num < 1000) return to_string(num);
	if (num < 1024000) return to_string(num / 1024) + "K";
	if (num < 1048576000) return to_string(num / 1048576) + "M";
	if (num < 1073741824000) return to_string(num / 1073741824) + "G";
	if (num < 1099511627776000) return to_string(num / 1099511627776) + "T";
	return "inf";
}

string format_ip(string ip)
{
	if (ip.compare("::") == 0)
	{
		return "  0.  0.  0.  0";
	}
	else
	{
		vector<string> octets = split(ip, '.');
		if (octets.size() == 4)
		{
			octets[0].insert(0, 3 - octets[0].length(), ' ');
			octets[1].insert(0, 3 - octets[1].length(), ' ');
			octets[2].insert(0, 3 - octets[2].length(), ' ');
			octets[3].insert(0, 3 - octets[3].length(), ' ');
			return octets[0] + "." + octets[1] + "." + octets[2] + "." + octets[3];
		}
		else
		{
			return ip;
		}
	}
}

static inline void ltrim(string& s) {
	s.erase(s.begin(), find_if(s.begin(), s.end(), [](unsigned char ch) {
		return !isspace(ch);
		}));
}

static inline void rtrim(string& s) {
	s.erase(find_if(s.rbegin(), s.rend(), [](unsigned char ch) {
		return !isspace(ch);
		}).base(), s.end());
}

static inline void trim(string& s) {
	ltrim(s);
	rtrim(s);
}

string truncate(string str, size_t width)
{
	if (str.length() > width)
		return str.substr(0, width);
	return str;
}

bool ip_match(string ip, string subnet)
{
	if (subnet.compare("*") == 0) return true;

	vector<string> ip_s = split(ip, '.');
	UINT ip_ = stoi(ip_s[0]) << 24 | stoi(ip_s[1]) << 16 | stoi(ip_s[2]) << 8 | stoi(ip_s[3]);

	vector<string> subnet_ = split(subnet, '/');
	vector<string> network = split(subnet_[0], '.');
	if (network.size() != 4) return false; //invalid
	UINT network_ = stoi(network[0]) << 24 | stoi(network[1]) << 16 | stoi(network[2]) << 8 | stoi(network[3]);
	UINT mask = 0xFFFFFFFF;
	if (subnet_.size() == 1);
	else if (subnet_.size() == 2)
		mask = mask << (32 - stoi(subnet_[1]));
	else
		return false;

	return ~(mask & (ip_ ^ network_)) == 0xFFFFFFFF;
}


struct socket_state
{
	string protocol = "";
	string local_ip = "";
	string local_port = "";
	string remote_ip = "";
	string remote_port = "";
	string direction = "";
	ULONG packets_in = 0;
	ULONG packets_out = 0;
	ULONG bytes_in = 0;
	ULONG bytes_out = 0;
	string status = "";
	string flags = "";
	time_t heartbeat = 0;
};

#define MAXBUF 65536
#define INET6_ADDRSTRLEN 45

UINT SHOW_LOOPBACK = 0;
UINT TIMEOUT = 5;
UINT TCP_TIMEOUT = 300;
UINT UDP_TIMEOUT = 10;
UINT REFRESH_INTERVAL = 1;
int mode = 0;
bool paused = false;

HANDLE s_handle;
HANDLE n_handle;
HANDLE console;

list<string> sockets_order = {};
unordered_map<string, socket_state*> sockets = {};

unordered_map<string, string> processByPort_ = {};

time_t activestat_heartbeat = 0;

mutex mtx_sockets;
mutex mtx_processByPort;
mutex mtx_console;
mutex mtx_queued;

string processById(DWORD id)
{
	HANDLE process = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, FALSE, id);
	DWORD path_len = 0;
	char path[MAX_PATH + 1];
	string filename = "";
	if (process != NULL)
	{
		path_len = GetProcessImageFileNameA(process, path, sizeof(path));
		CloseHandle(process);
	}
	if (path_len != 0)
	{
		char* filename_ = PathFindFileNameA(path);
		filename = string(filename_);
	}
	else if (id == 4)
	{
		filename = "System";
	}
	else
	{
		filename = "pid=" + to_string(id);
	}

	return filename;
}

string processByPort(string protocol, string ip, string port)
{
	string tuple1 = protocol + " " + ip + ":" + port;
	string tuple2 = protocol + " 0.0.0.0:" + port;

	string process = "";

	mtx_processByPort.lock();

	if (processByPort_.find(tuple1) != processByPort_.cend())
	{
		process = processByPort_[tuple1];
	}
	else if (processByPort_.find(tuple2) != processByPort_.cend())
	{
		process = processByPort_[tuple2];
	}

	mtx_processByPort.unlock();

	return process;
}

void socket_update_status(socket_state* socket_state_, string direction, bool fin, bool syn, bool rst, bool psh, bool ack)
{
	if (socket_state_->protocol.compare("UDP") == 0)
	{
		if (socket_state_->status.compare("") == 0)
		{
			if (socket_state_->direction.compare(direction) == 0)
			{
				socket_state_->status = "CNCT";
			}
		}
		else if (socket_state_->status.compare("CNCT") == 0)
		{
			if (socket_state_->direction.compare(direction) != 0)
			{
				socket_state_->status = "EST";
			}
		}
		else if (socket_state_->status.compare("TOUT") == 0)
		{
			socket_state_->status = "EST";
		}
	}
	else if (socket_state_->protocol.compare("TCP") == 0)
	{
		if (socket_state_->status.compare("") == 0 && socket_state_->direction.compare(direction) == 0)
		{
			socket_state_->status = "PTRU";
		}

		if (socket_state_->status.compare("PTRU") == 0 && socket_state_->direction.compare(direction) != 0)
		{
			socket_state_->status = "EST";
		}

		if (syn && !ack && socket_state_->direction.compare(direction) == 0)
		{
			socket_state_->status = "CNCT";
		}

		if (syn && ack && socket_state_->direction.compare(direction) != 0)
		{
			socket_state_->status = "EST";
		}

		if (rst)
		{
			if (direction.compare("->") == 0)
			{
				socket_state_->status = "LRST";
			}
			else if (direction.compare("<-") == 0)
			{
				socket_state_->status = "RRST";
			}
		}

		if (fin)
		{
			if (socket_state_->status.compare("LFIN") == 0)
			{
				if (direction.compare("<-") == 0)
				{
					socket_state_->status = "CLSD";
				}
			}
			else if (socket_state_->status.compare("RFIN") == 0)
			{
				if (direction.compare("->") == 0)
				{
					socket_state_->status = "CLSD";
				}
			}
			else
			{
				if (direction.compare("->") == 0)
				{
					socket_state_->status = "LFIN";
				}
				else if (direction.compare("<-") == 0)
				{
					socket_state_->status = "RFIN";
				}
			}
		}
	}
}

void process_packet(time_t now, string direction,
	string protocol, string local_ip, string local_port, string remote_ip, string remote_port,
	UINT packet_len, bool fin, bool syn, bool rst, bool psh, bool ack,
	bool packet)
{
	string tuple = protocol + " " + local_ip + ":" + local_port + " " + remote_ip + ":" + remote_port;

	socket_state* socket_state_;

	mtx_sockets.lock();

	if (sockets.find(tuple) == sockets.cend())
	{
		socket_state_ = new socket_state();

		socket_state_->protocol = protocol;
		socket_state_->local_ip = local_ip;
		socket_state_->local_port = local_port;
		socket_state_->remote_ip = remote_ip;
		socket_state_->remote_port = remote_port;
		socket_state_->direction = direction;
		socket_state_->status = "";
		socket_state_->heartbeat = now;

		socket_update_status(socket_state_, direction, fin, syn, rst, psh, ack);

		sockets[tuple] = socket_state_;

		sockets_order.push_front(tuple);
	}
	else
	{
		socket_state_ = sockets[tuple];

		socket_state_->heartbeat = now;

		socket_update_status(socket_state_, direction, fin, syn, rst, psh, ack);
	}

	if (packet)
	{
		if (direction.compare("->") == 0)
		{
			socket_state_->packets_out++;
			socket_state_->bytes_out += packet_len;
		}
		else if (direction.compare("<-") == 0)
		{
			socket_state_->packets_in++;
			socket_state_->bytes_in += packet_len;
		}
	}

	list<string>::iterator i = find(sockets_order.begin(), sockets_order.end(), tuple);
	if (i != sockets_order.end())
	{
		i = sockets_order.erase(i);
		sockets_order.push_front(tuple);
	}

	mtx_sockets.unlock();
}

void load()
{
	ifstream file;
	string line;
	UINT lineno;

	for (; ; )
	{
		bool error = false;

		cout << "  VALIDATING SETTINGS: " << endl;

		file = ifstream("settings.txt");
		lineno = 1;
		while (getline(file, line))
		{
			vector<string> args = split_args(line);
			if (args.size() == 0);
			else if (args.size() == 2)
			{
				int value;
				try
				{
					value = stoi(args[1]);
					if (value < 0)
					{
						cout << "    ERROR at line " << lineno << ": Invalid value" << endl;
						error = true;
					}
				}
				catch (const std::exception&)
				{
					cout << "    ERROR at line " << lineno << ": Invalid value" << endl;
					error = true;
				}
			}
			else
			{
				cout << "    ERROR at line " << lineno << ": Expected 2 arguments" << endl;
				error = true;
			}
			lineno++;
		}

		cout << endl;

		if (error)
		{
			cout << "  FAILED!" << endl << endl;

			cout << "  Fix errors and press any key...";
			_getch();
		}
		else
		{
			cout << "  PASSED!" << endl << endl;
			break;
		}
	}

	cout << endl;


	cout << "  LOADING SETTINGS: ";

	file = ifstream("settings.txt");
	while (getline(file, line))
	{
		vector<string> args = split_args(line);
		if (args.size() == 0);
		else if (args.size() == 2)
		{
			if (args[0].compare("SHOW_LOOPBACK") == 0)
				SHOW_LOOPBACK = stoi(args[1]);
			else if (args[0].compare("TIMEOUT") == 0)
				TIMEOUT = stoi(args[1]);
			else if (args[0].compare("TCP_TIMEOUT") == 0)
				TCP_TIMEOUT = stoi(args[1]);
			else if (args[0].compare("UDP_TIMEOUT") == 0)
				UDP_TIMEOUT = stoi(args[1]);
		}
	}

	cout << "DONE!" << endl << endl;
}

bool init()
{
	system("cls");

	cout << endl << endl;

	load();

	cout << "  OPENING SOCKET HANDLE: ";

	s_handle = WinDivertOpen(
		"true",
		WINDIVERT_LAYER_SOCKET, -1, WINDIVERT_FLAG_SNIFF + WINDIVERT_FLAG_READ_ONLY);
	if (s_handle == INVALID_HANDLE_VALUE)
	{
		cout << "ERROR: " << GetLastError() << endl;
		return false;
	}

	cout << "DONE!" << endl << endl;



	cout << "  OPENING NETWORK HANDLE: ";

	n_handle = WinDivertOpen(
		"true",
		WINDIVERT_LAYER_NETWORK, -2, WINDIVERT_FLAG_SNIFF + WINDIVERT_FLAG_READ_ONLY);
	if (n_handle == INVALID_HANDLE_VALUE)
	{
		cout << "ERROR: " << GetLastError() << endl;
		return false;
	}

	cout << "DONE!" << endl << endl;



	cout << "  NETSTAT -A -N -O > NETSTAT.TXT: ";

	system("netstat -a -n -o > netstat.txt");

	cout << "DONE!" << endl << endl;



	time_t now;
	time(&now);


	cout << "  PARSING NETSTAT.TXT: ";

	ifstream file = ifstream("netstat.txt");
	string line;
	while (getline(file, line))
	{
		vector<string> args = split_args(line);
		string protocol = "";
		if (args.size() > 0) protocol = args[0];
		string local_ip;
		string local_port;
		string remote_ip;
		string remote_port;
		if (protocol.compare("TCP") == 0 && args.size() == 5 ||
			protocol.compare("UDP") == 0 && args.size() == 4)
		{
			vector<string> local_s = split(args[1], ':');
			if (local_s.size() != 2) continue; //possible ipv6
			local_ip = local_s[0];
			local_port = local_s[1];

			vector<string> remote_s = split(args[2], ':');
			if (remote_s.size() != 2) continue; //possible ipv6
			remote_ip = remote_s[0];
			remote_port = remote_s[1];

			DWORD processId = 0;
			string state = "";
			if (protocol.compare("TCP") == 0)
			{
				state = args[3];
				processId = stoul(args[4]);
			}
			else if (protocol.compare("UDP") == 0)
			{
				processId = stoul(args[3]);
			}

			string process = processById(processId);

			processByPort_[protocol + " " + local_ip + ":" + local_port] = process;

			//if (state.compare("SYN_SENT") == 0)
			//{
			//	process_packet(now, "->",
			//		protocol, local_ip, local_port, remote_ip, remote_port, 0,
			//		false, true, false, false, false,
			//		false);
			//}
			//else if (state.compare("SYN_RECV") == 0)
			//{
			//	process_packet(now, "<-",
			//		protocol, local_ip, local_port, remote_ip, remote_port, 0,
			//		false, true, false, false, false,
			//		false);
			//}
			//else if (state.compare("ESTABLISHED") == 0)
			//{
			//	process_packet(now, "->",
			//		protocol, local_ip, local_port, remote_ip, remote_port, 0,
			//		false, true, false, false, false,
			//		false);
			//	process_packet(now, "<-",
			//		protocol, local_ip, local_port, remote_ip, remote_port, 0,
			//		false, true, false, false, true,
			//		false);
			//}
		}
		//if
	}
	//while (getline(file, line))

	cout << "DONE!" << endl << endl;

	return true;
}

void reload()
{
	mtx_console.lock();

	system("cls");

	cout << endl << endl;

	load();

	mtx_console.unlock();
}

void socket_()
{
	for (ULONG i = 0; ; i++)
	{
		WINDIVERT_ADDRESS addr;
		if (!WinDivertRecv(s_handle, NULL, 0, NULL, &addr))	continue;
		if (addr.IPv6) continue;

		mtx_queued.lock();

		time_t now;

		time(&now);

		string process = processById(addr.Socket.ProcessId);

		string event;
		switch (addr.Event)
		{
		case WINDIVERT_EVENT_SOCKET_BIND:
			event = "BIND";
			break;
		case WINDIVERT_EVENT_SOCKET_LISTEN:
			event = "LISTEN";
			break;
		case WINDIVERT_EVENT_SOCKET_CONNECT:
			event = "CONNECT";
			break;
		case WINDIVERT_EVENT_SOCKET_ACCEPT:
			event = "ACCEPT";
			break;
		case WINDIVERT_EVENT_SOCKET_CLOSE:
			event = "CLOSE";
			break;
		default:
			event = "";
			break;
		}

		string protocol;
		switch (addr.Socket.Protocol)
		{
		case IPPROTO_TCP:
			protocol = "TCP";
			break;
		case IPPROTO_UDP:
			protocol = "UDP";
			break;
		case IPPROTO_ICMP:
			protocol = "ICMP";
			break;
		case IPPROTO_ICMPV6:
			protocol = "ICMPV6";
			break;
		default:
			protocol = to_string(addr.Socket.Protocol);
			break;
		}

		string direction;
		if (addr.Outbound)
			direction = "->";
		else
			direction = "<-";


		char local_str[INET6_ADDRSTRLEN + 1], remote_str[INET6_ADDRSTRLEN + 1];

		WinDivertHelperFormatIPv6Address(addr.Socket.LocalAddr, local_str, sizeof(local_str));
		WinDivertHelperFormatIPv6Address(addr.Socket.RemoteAddr, remote_str, sizeof(remote_str));

		string local_ip = string(local_str);
		if (local_ip.compare("::") == 0) local_ip = "0.0.0.0";
		string local_port = to_string(addr.Socket.LocalPort);

		string remote_ip = string(remote_str);
		if (remote_ip.compare("::") == 0) remote_ip = "0.0.0.0";
		string remote_port = to_string(addr.Socket.RemotePort);

		//log_(now, protocol, direction, local_ip, local_port, remote_ip, remote_port, process, event);

		if (event.compare("BIND") == 0 || (addr.Loopback && event.compare("CONNECT") == 0))
		{
			mtx_processByPort.lock();
			processByPort_[protocol + " " + local_ip + ":" + local_port] = process;
			mtx_processByPort.unlock();
		}
		else if (event.compare("CLOSE") == 0 && remote_ip.compare("0.0.0.0") == 0 && remote_port.compare("0") == 0)
		{
			//mtx_processByPort.lock();
			//processByPort_.erase(protocol + " " + local_ip + ":" + local_port);
			//mtx_processByPort.unlock();
		}

		mtx_queued.unlock();
	}
}

void network()
{
	WINDIVERT_ADDRESS addr; // Packet address
	char packet[MAXBUF];    // Packet buffer
	UINT packet_len;

	PWINDIVERT_IPHDR ip_header;
	PWINDIVERT_IPV6HDR ipv6_header;
	PWINDIVERT_ICMPHDR icmp_header;
	PWINDIVERT_ICMPV6HDR icmpv6_header;
	PWINDIVERT_TCPHDR tcp_header;
	PWINDIVERT_UDPHDR udp_header;
	char src_str[INET6_ADDRSTRLEN + 1], dst_str[INET6_ADDRSTRLEN + 1];
	PVOID payload;
	UINT payload_len;

	string protocol;
	string src_ip, dst_ip;
	bool fin, syn, rst, psh, ack;
	string direction;

	string src_port, dst_port;

	time_t now;

	for (ULONG i = 0; ; i++)
	{
		if (!WinDivertRecv(n_handle, packet, sizeof(packet), &packet_len, &addr)) continue;

		mtx_queued.lock();

		time(&now);

		WinDivertHelperParsePacket(packet, packet_len, &ip_header, &ipv6_header,
			NULL, &icmp_header, &icmpv6_header, &tcp_header, &udp_header, &payload,
			&payload_len, NULL, NULL);

		if (ip_header == NULL || (tcp_header == NULL && udp_header == NULL))
		{
			goto cont;
		}

		WinDivertHelperFormatIPv4Address(ntohl(ip_header->SrcAddr), src_str, sizeof(src_str));
		WinDivertHelperFormatIPv4Address(ntohl(ip_header->DstAddr), dst_str, sizeof(dst_str));

		src_ip = string(src_str);
		dst_ip = string(dst_str);

		fin = false;
		syn = false;
		rst = false;
		psh = false;
		ack = false;

		if (tcp_header != NULL)
		{
			protocol = "TCP";

			src_port = to_string(ntohs(tcp_header->SrcPort));
			dst_port = to_string(ntohs(tcp_header->DstPort));

			fin = tcp_header->Fin;
			syn = tcp_header->Syn;
			rst = tcp_header->Rst;
			psh = tcp_header->Psh;
			ack = tcp_header->Ack;
		}

		if (udp_header != NULL)
		{
			protocol = "UDP";
			src_port = to_string(ntohs(udp_header->SrcPort));
			dst_port = to_string(ntohs(udp_header->DstPort));
		}

		if (addr.Loopback)
		{
			process_packet(now, "->",
				protocol, src_ip, src_port, dst_ip, dst_port,
				packet_len, fin, syn, rst, psh, ack, true);
			process_packet(now, "<-",
				protocol, dst_ip, dst_port, src_ip, src_port,
				packet_len, fin, syn, rst, psh, ack, true);
		}
		else if (addr.Outbound)
		{
			process_packet(now, "->",
				protocol, src_ip, src_port, dst_ip, dst_port,
				packet_len, fin, syn, rst, psh, ack, true);
		}
		else
		{
			process_packet(now, "<-",
				protocol, dst_ip, dst_port, src_ip, src_port,
				packet_len, fin, syn, rst, psh, ack, true);
		}


	cont:
		mtx_queued.unlock();
	}
}

void heartbeat()
{
	for (;;)
	{
		mtx_sockets.lock();

		time_t now;
		time(&now);

		for (unordered_map<string, socket_state*>::iterator i = sockets.begin(); i != sockets.end(); )
		{
			string tuple = i->first;
			socket_state* socket_state_ = i->second;

			if (socket_state_->status.compare("EST") != 0 &&
				difftime(now, socket_state_->heartbeat) >= TIMEOUT)
			{
				sockets_order.remove(tuple);
				i = sockets.erase(i);
				delete socket_state_;
				continue;
			}

			if (socket_state_->status.compare("TOUT") != 0)
			{
				if (socket_state_->protocol.compare("UDP") == 0 && difftime(now, socket_state_->heartbeat) >= UDP_TIMEOUT ||
					socket_state_->protocol.compare("TCP") == 0 && difftime(now, socket_state_->heartbeat) >= TCP_TIMEOUT)
				{
					socket_state_->status = "TOUT";
					socket_state_->heartbeat = now;
				}
			}

			i++;
		}

		mtx_sockets.unlock();

		this_thread::sleep_for(chrono::seconds(1));
	}
}

void activestat()
{
	for (; ; )
	{
		if (mode == 0 && !paused)
		{
			mtx_console.lock();

			time_t now;
			time(&now);

			if (difftime(now, activestat_heartbeat) >= REFRESH_INTERVAL)
			{
				mtx_sockets.lock();

				system("cls");

				CONSOLE_SCREEN_BUFFER_INFO csbi;
				GetConsoleScreenBufferInfo(console, &csbi);
				short rows = csbi.srWindow.Bottom - csbi.srWindow.Top + 1;
				short columns = csbi.srWindow.Right - csbi.srWindow.Left + 1;

				SetConsoleTextAttribute(console, 31);
				cout
					<< left
					<< setw((streamsize)columns - 1) << "PRO STAT LOCAL                  REMOTE                RECV SENT IDL PROCESS" << endl
					<< right;

				size_t row = 0;
				for (list<string>::iterator i = sockets_order.begin(); i != sockets_order.end(); i++)
				{
					if (row + 2 == (size_t)rows)
						break;

					string& tuple = *i;
					socket_state* socket_state_ = sockets[tuple];
					
					if (!(socket_state_->local_ip.compare(socket_state_->remote_ip) == 0 || ip_match(socket_state_->local_ip, "127.0.0.1/8")) || SHOW_LOOPBACK != 0)
					{
						ULONG idle = difftime(now, socket_state_->heartbeat);
						string idle_ = idle > 999 ? "000" : to_string(idle);

						if (socket_state_->status.compare("CNCT") == 0 ||
							socket_state_->status.compare("PTRU") == 0)
							SetConsoleTextAttribute(console, 14);
						else if (socket_state_->status.compare("EST") == 0)
							SetConsoleTextAttribute(console, 10);
						else
							SetConsoleTextAttribute(console, 9);

						cout
							<< left
							<< socket_state_->protocol << " "
							<< setw(4) << socket_state_->status << " "
							<< right
							<< format_ip(socket_state_->local_ip) << ":" << setw(5) << socket_state_->local_port
							<< "  " /* socket_state_->direction */
							<< format_ip(socket_state_->remote_ip) << ":" << setw(5) << socket_state_->remote_port << " "
							/* << setw(4) << format(socket_state_->packets_in) << " " */ << setw(4) << format(socket_state_->bytes_in) << " "
							/* << setw(4) << format(socket_state_->packets_out) << " " */ << setw(4) << format(socket_state_->bytes_out) << " "
							<< setw(3) << idle_ << " "
							<< left
							<< setw((streamsize)columns - 69) << truncate(processByPort(socket_state_->protocol, socket_state_->local_ip, socket_state_->local_port), (streamsize)columns - 69)
							<< right
							<< endl;
						row++;
					}
				}

				for (; row + 2 < (size_t)rows; row++)
				{
					cout << endl;
				}

				SetConsoleTextAttribute(console, 31);
				cout << "RE[L]OAD   [R]EFRESH: [-] " << setw(2) << REFRESH_INTERVAL << "s [+]   [P]AUSE   LEGEN[D]   [Q]UIT" << setw((streamsize)columns - 64) << " ";

				mtx_sockets.unlock();

				activestat_heartbeat = now;

				SetConsoleTextAttribute(console, 15);
			}

			mtx_console.unlock();
		}

		this_thread::sleep_for(chrono::seconds(1));
	}
}

void legend()
{
	mtx_console.lock();

	system("cls");

	cout << endl << endl;

	SetConsoleTextAttribute(console, 15);
	cout << "  LEGEND:" << endl << endl;

	SetConsoleTextAttribute(console, 15);
	cout << "    ACTIVE STAT:" << endl << endl;

	SetConsoleTextAttribute(console, 14);
	cout << "      CNCT: Connecting" << endl << endl;

	cout << "      PTRU: Passed through without SYN" << endl << endl;

	SetConsoleTextAttribute(console, 10);
	cout << "      EST : Established" << endl << endl;

	SetConsoleTextAttribute(console, 9);
	cout << "      LFIN: FIN Sent" << endl;
	cout << "      RFIN: FIN Received" << endl;
	cout << "      CLSD: Closed" << endl << endl;

	cout << "      LRST: RST Sent" << endl;
	cout << "      RRST: RST Received" << endl << endl;

	cout << "      TOUT: Inactivity Time-out" << endl << endl;

	SetConsoleTextAttribute(console, 15);
	cout << "  PRESS [D] AGAIN TO RETURN" << endl << endl;

	mtx_console.unlock();

	while (toupper(_getch()) != 'D');
}

int main()
{
	console = GetStdHandle(STD_OUTPUT_HANDLE);

	if (!init()) return 1;

	thread socket_(socket_);
	thread network(network);
	thread heartbeat(heartbeat);
	thread activestat(activestat);

	CONSOLE_SCREEN_BUFFER_INFO csbi;
	short rows, columns;

	for (; ; )
	{
		int c = toupper(_getch());
		switch (c)
		{
		case 'L':
			reload();
			activestat_heartbeat = 0;
			break;

		case '+':
			switch (REFRESH_INTERVAL)
			{
			case 1:
				REFRESH_INTERVAL = 5;
				break;
			case 5:
				REFRESH_INTERVAL = 15;
				break;
			case 15:
				REFRESH_INTERVAL = 60;
				break;
			case 60:
				break;
			}
			activestat_heartbeat = 0;
			break;

		case '-':
			switch (REFRESH_INTERVAL)
			{
			case 1:
				break;
			case 5:
				REFRESH_INTERVAL = 1;
				break;
			case 15:
				REFRESH_INTERVAL = 5;
				break;
			case 60:
				REFRESH_INTERVAL = 15;
				break;
			}
			activestat_heartbeat = 0;
			break;

		case 'R':
			activestat_heartbeat = 0;
			break;

		case 'P':

			paused = true;

			mtx_console.lock();

			GetConsoleScreenBufferInfo(console, &csbi);
			rows = csbi.srWindow.Bottom - csbi.srWindow.Top + 1;
			columns = csbi.srWindow.Right - csbi.srWindow.Left + 1;

			SetConsoleTextAttribute(console, 31);
			cout << "\r" << left << setw((streamsize)columns - 1) << "PAUSED: PRESS [P] AGAIN TO CONTINUE" << right;
			SetConsoleTextAttribute(console, 15);

			mtx_console.unlock();

			while (toupper(_getch()) != 'P');

			activestat_heartbeat = 0;

			paused = false;

			break;

		case 'D':

			mode = -1;

			legend();

			activestat_heartbeat = 0;

			mode = 0;

			break;

		case 'Q':

			goto exit;

		}
	}

exit:;

	exit(0);
}
