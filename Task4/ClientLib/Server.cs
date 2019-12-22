using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    /// <summary>
    /// Server class to communicate with clients using the TCP/IP Protocol stack.
    /// </summary>
    public class Server
    {

        private IPAddress ipAddress;
        private int port;
        private IPEndPoint endPoint;
        private Socket socket;
        private Socket socketListener;
        private int clientsCount;

        private ServerMessageHandler handler;

        /// <summary>
        /// Initializes a new instance of the Server class.
        /// </summary>
        /// <param name="port">A port.</param>
        /// <param name="ipAddressStr">IP address.</param>
        /// <param name="count">The maximum length of the pending connections queue.</param>
        public Server(int count, int port = 11000, string ipAddressStr = "127.0.0.1")
        {
            this.port = port;
            ipAddress = IPAddress.Parse(ipAddressStr);
            endPoint = new IPEndPoint(ipAddress, port);
            socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListener.Bind(endPoint);
            clientsCount = count;
            SetEvent();
        }

        private void SetEvent()
        {
            handler = new ServerMessageHandler();

            handler.MsgEvent += (Message msg) =>
            {
                handler.messages.Add(msg);
            };
        }

        /// <summary>
        /// Wait a new client connection.
        /// </summary>
        public void WaitClientConnection()
        {
            if (socketListener != null)
            {
                socketListener.Listen(clientsCount);
                socket = socket.Accept();
            }
            else
            {
                throw new Exception("Server socket listener wasn't created");
            }
        }

        /// <summary>
        /// Method for receiving messages from clients.
        /// </summary>
        /// <returns></returns>
        public string Listen()
        {
            socket.Listen(clientsCount);
            while (true)
            {
                Socket listener = socket.Accept();
                byte[] buffer = new byte[1024];
                var size = 0;
                StringBuilder data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                }
                while (listener.Available > 0);

                byte[] msg = Encoding.UTF8.GetBytes("Successfully");
                listener.Send(msg);

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();

                return data.ToString();
            }
        }

        private void SendString(string text)
        {
            byte[] bytes = new byte[1024];

            bytes = Encoding.ASCII.GetBytes(text);

            socket.Send(bytes);
        }

        private string ReceiveString()
        {
            byte[] recvdData = new byte[1024];
            string text = null;
            int numBytes;

            numBytes = socket.Receive(recvdData);
            text = Encoding.ASCII.GetString(recvdData, 0, numBytes);

            return text;
        }

        /// <summary>
        /// Receive message.
        /// </summary>
        /// <returns></returns>
        public Message Receive()
        {
            string clientName = ReceiveString();
            string msgText = ReceiveString();

            Message message = new Message(msgText, new Client(clientName));
            handler.OnLoadMessage(message);

            return message;
        }

        /// <summary>
        /// Send a message to the client
        /// </summary>
        /// <param name="msg"> Message instance</param>
        public void Send(Message msg)
        {
            SendString(msg.ToString() + " - Succesfully");
        }
    }
}
