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
    public partial class TcpServer
    {

        #region definitions

        public class AcceptedEventArgs : EventArgs
        {
            public readonly TcpClient TcpClient;

            public AcceptedEventArgs(TcpClient tcpClient)
            {
                this.TcpClient = tcpClient;
            }
        }

        public delegate void AcceptedEventHandler(object sender, AcceptedEventArgs e);

        private delegate void OnAcceptedCallback(AcceptedEventArgs e);

        #endregion

        #region fields

        ushort localPort = 0;
        Socket socket = null;

        #endregion

        #region events

        public event AcceptedEventHandler Accepted;

        #endregion

        #region methods

        void beginAccept()
        {
            try { socket.BeginAccept(new AsyncCallback(endAccept), socket); }
            catch { }
        }

        public void endAccept(IAsyncResult ar)
        {
            beginAccept();

            try
            {
                Socket socket = (Socket)ar.AsyncState;
                Socket client = socket.EndAccept(ar);

                TcpClient tcpClient = new TcpClient(client);
                OnAccepted(new AcceptedEventArgs(tcpClient));
                tcpClient.beginReceive();
            }
            catch
            {
            }
        }

        public bool Listen()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (localPort != 0)
                    socket.Bind(new IPEndPoint(IPAddress.Any, localPort));
                socket.Listen(0);
                beginAccept();
                return true;
            }
            catch
            {
                Close();
                return false;
            }
        }

        public bool IsListening()
        {
            return socket != null;
        }

        public void Close()
        {
            if (socket == null)
                return;

            socket.Close();
            socket = null;
        }

        protected void OnAccepted(AcceptedEventArgs e)
        {
            if (false /*this.InvokeRequired*/)
            {
                //this.Invoke(new OnAcceptedCallback(OnAccepted), e);
            }
            else
            {
                if (Accepted != null)
                    Accepted(this, e);
            }
        }

        #endregion

        #region constructors

        public TcpServer()
        {
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

        #endregion

    }
}
