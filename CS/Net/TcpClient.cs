using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace CS.Net
{
    public partial class TcpClient
    {

        #region constants

        const int receiveBufferSize = 4096;

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

        public class DisconnectedEventArgs : EventArgs
        {
            public enum ReasonEnum
            {
                Local,
                Remote,
                Error
            }

            public readonly ReasonEnum Reason;

            public DisconnectedEventArgs(ReasonEnum reason)
            {
                this.Reason = reason;
            }
        }

        public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);
        public delegate void DisconnectedEventHandler(object sender, DisconnectedEventArgs e);

        public delegate void OnConnectedCallback(EventArgs e);
        public delegate void OnDataReceivedCallback(DataReceivedEventArgs e);
        public delegate void OnDisconnectedCallback(DisconnectedEventArgs e);

        #endregion

        #region fields

        ushort localPort = 0;
        string hostname = "";
        ushort remotePort = 0;
        int receiveTimeout = 0;
        IPEndPoint remoteEndPoint;

        internal Socket socket = null;
        byte[] receiveBuffer = new byte[receiveBufferSize];
        System.Timers.Timer receiveTimer = new System.Timers.Timer();

        #endregion

        #region events

        public event DataReceivedEventHandler DataReceived;

        public event EventHandler Connected;

        public event DisconnectedEventHandler Disconnected;

        #endregion

        #region methods

        internal void beginReceive()
        {
            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, 0);
            EndPoint ep = ipEp;

            try { socket.BeginReceiveFrom(receiveBuffer, 0, receiveBufferSize, SocketFlags.None, ref ep, new AsyncCallback(endReceive), socket); }
            catch { }

            if (receiveTimeout != 0)
            {
                receiveTimer.Interval = receiveTimeout;
                receiveTimer.Start();
            }
        }

        private void endReceive(IAsyncResult ar)
        {
            receiveTimer.Stop();

            Socket socket = (Socket)ar.AsyncState;

            if (!socket.Connected)
            {
                OnDisconnected(new DisconnectedEventArgs(DisconnectedEventArgs.ReasonEnum.Local));
                return;
            }

            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, 0);
            EndPoint ep = ipEp;

            int bytes = 0;
            try
            {
                bytes = socket.EndReceiveFrom(ar, ref ep);
            }
            catch //(Exception ex)
            {
                OnDisconnected(new DisconnectedEventArgs(DisconnectedEventArgs.ReasonEnum.Error));
                return;
            }

            if (bytes == 0)
            {
                OnDisconnected(new DisconnectedEventArgs(DisconnectedEventArgs.ReasonEnum.Remote));
                return;
            }

            byte[] data = new byte[bytes];
            Array.Copy(receiveBuffer, data, bytes);

            OnDataReceived(new DataReceivedEventArgs((IPEndPoint)ep, data));

            beginReceive();
        }

        private void receiveTimout(object sender, ElapsedEventArgs e)
        {
            Close();
        }

        public bool Open()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (localPort != 0)
                    socket.Bind(new IPEndPoint(IPAddress.Any, localPort));

                IPAddress[] ipAddresses = Dns.GetHostAddresses(hostname);
                socket.Connect(new IPEndPoint(ipAddresses[0], remotePort));

                remoteEndPoint = (IPEndPoint)RemoteEndPoint;

                OnConnected(new EventArgs());

                beginReceive();

                return true;
            }
            catch
            {
                Close();
                return false;
            }
        }

        public bool IsOpen()
        {
            return (socket != null && socket.Connected);
        }

        public bool Send(byte[] data)
        {
            if (socket == null)
                return false;

            try { socket.Send(data); }
            catch { return false; }

            return true;
        }

        public void Close()
        {
            if (socket == null)
                return;

            socket.Close();
            //socket = null;
        }

        protected void OnConnected(EventArgs e)
        {
            if (false /*this.InvokeRequired*/)
            {
                //this.Invoke(new OnConnectedCallback(OnConnected), e);
            }
            else
            {
                if (Connected != null)
                    Connected(this, e);
            }
        }

        protected void OnDataReceived(DataReceivedEventArgs e)
        {
            if (false /*this.InvokeRequired*/)
            {
                //this.Invoke(new OnDataReceivedCallback(OnDataReceived), e);
            }
            else
            {
                if (DataReceived != null)
                    DataReceived(this, e);
            }
        }

        protected void OnDisconnected(DisconnectedEventArgs e)
        {
            if (false /*this.InvokeRequired*/)
            {
                //this.Invoke(new OnDisconnectedCallback(OnDisconnected), e);
            }
            else
            {
                if (Disconnected != null)
                    Disconnected(this, e);
            }
        }

        #endregion

        #region constructors

        public TcpClient()
        {
            receiveTimer.AutoReset = false; 
            receiveTimer.Elapsed += new ElapsedEventHandler(receiveTimout);
        }

        internal TcpClient(Socket socket) : this()
        {
            this.socket = socket;
            remoteEndPoint = (IPEndPoint)socket.RemoteEndPoint;
        }

        #endregion

        #region properties

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

        public int ReceiveTimeout
        {
            get
            {
                return receiveTimeout;
            }
            set
            {
                receiveTimeout = value;
            }
        }

        public IPEndPoint RemoteEndPoint
        {
            get
            {
                return remoteEndPoint;
            }
        }

        #endregion

    }
}
