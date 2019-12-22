using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientLib;

namespace ServerLib
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

        /// <summary>
        /// Client messages
        /// </summary>
        private List<Message> messages = new List<Message>();

        /// <summary>
        /// Get all client messages
        /// </summary>
        /// <returns></returns>
        public List<Message> GetAllMessages()
        {
            return messages;
        }

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
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            clientsCount = count;
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
    }
}
