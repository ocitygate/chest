using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace CS.Net
{
    public partial class UdpClient
    {

        #region constants

        const int receiveBufferSize = 2048;

        #endregion

        #region definitions

        public class DataReceivedEventArgs : EventArgs
        {
            public readonly IPEndPoint RemoteEP;
            public readonly byte[] Data;

            public DataReceivedEventArgs(IPEndPoint remoteEP, byte[] data)
            {
                this.RemoteEP = remoteEP;
                this.Data = data;
            }
        }

        public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

        #endregion

        #region fields

        bool serverMode = false;
        ushort localPort = 0;
        string hostname = "";
        ushort remotePort = 0;

        Socket socket = null;
        byte[] receiveBuffer = new byte[receiveBufferSize];

        #endregion

        #region events

        public event DataReceivedEventHandler DataReceived;

        #endregion

        #region methods

        void beginReceive()
        {
            if (socket == null)
                return;

            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, 0);
            EndPoint ep = ipEp;

            try { socket.BeginReceiveFrom(receiveBuffer, 0, receiveBufferSize, SocketFlags.None, ref ep, new AsyncCallback(endReceive), socket); }
            catch { }
        }

        void endReceive(IAsyncResult ar)
        {
            if (socket == null)
                return;

            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, 0);
            EndPoint ep = ipEp;

            int bytes = 0;
            try { bytes = socket.EndReceiveFrom(ar, ref ep); }
            catch { }

            byte[] data = new byte[bytes];
            Array.Copy(receiveBuffer, data, bytes);

            if (DataReceived != null)
                DataReceived(this, new DataReceivedEventArgs((IPEndPoint)ep, data));

            beginReceive();
        }

        public bool Open()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                socket.EnableBroadcast = true;
                socket.DontFragment = true;

                if (localPort != 0)
                    socket.Bind(new IPEndPoint(IPAddress.Any, localPort));

                if (!serverMode)
                {
                    IPAddress[] ipAddresses = Dns.GetHostAddresses(hostname);
                    socket.Connect(new IPEndPoint(ipAddresses[0], remotePort));
                }
            }
            catch
            {
                Close();
                return false;
            }

            beginReceive();

            return true;
        }

        public bool IsOpen()
        {
            return socket != null;
        }

        public bool Send(byte[] data)
        {
            try { socket.Send(data); }
            catch { return false; }

            return true;
        }

        public bool Send(byte[] data, string hostname, ushort port)
        {
            try
            {
                IPAddress[] ipAddresses = Dns.GetHostAddresses(hostname);
                socket.SendTo(data, new IPEndPoint(ipAddresses[0], port));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Close()
        {
            if (!IsOpen())
                return;

            Socket temp = socket;
            socket = null;
            temp.Close();
        }

        #endregion

        #region constructors

        public UdpClient()
        {
        }

        #endregion

        #region properties

        public bool ServerMode
        {
            get
            {
                return serverMode;
            }
            set
            {
                serverMode = value;
            }
        }

        public ushort LocalPort
        {
            get
            {
                return localPort;
            }
            set
            {
                localPort = value;
            }
        }

        public string Hostname
        {
            get
            {
                return hostname;
            }
            set
            {
                hostname = value;
            }
        }

        public ushort RemotePort
        {
            get
            {
                return remotePort;
            }
            set
            {
                remotePort = value;
            }
        }

        #endregion

    }
}
