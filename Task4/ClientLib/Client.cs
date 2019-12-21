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
    /// Client class to communicate with the server using the TCP/IP Protocol stack.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client's name.
        /// </summary>
        public string Name { get; private set; }

        private IPAddress ipAddress;
        private int port;
        private IPEndPoint endPoint;
        private Socket socket;


        /// <summary>
        /// Initializes a new instance of the Client class.
        /// </summary>
        /// <param name="name">Client's name.</param>
        /// <param name="port">A port.</param>
        /// <param name="ipAddressStr">The server IP address.</param>
        public Client(string name, int port = 11000, string ipAddressStr = "127.0.0.1")
        {
            Name = name;
            this.port = port;
            ipAddress = IPAddress.Parse(ipAddressStr);
            endPoint = new IPEndPoint(ipAddress , port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Method to send a message to the server and receive a response.
        /// </summary>
        /// <param name="msg">A message sent to the server.</param>
        /// <returns></returns>
        public string SendMessage(string msg)
        {
            var data = Encoding.UTF8.GetBytes(msg);
            socket.Connect(endPoint);
            socket.Send(data);

            byte[] buffer = new byte[1024];
            var size = 0;
            StringBuilder serverAnswer = new StringBuilder();

            do
            {
                size = socket.Receive(buffer);
                serverAnswer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            }
            while (socket.Available > 0);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

            return serverAnswer.ToString();
        }
    }
}
