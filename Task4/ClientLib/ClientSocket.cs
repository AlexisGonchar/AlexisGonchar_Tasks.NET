using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientLib
{
    /// <summary>
    /// Representing a client socket.
    /// </summary>
    public class ClientSocket
    {

        private Socket socket;
        private Client client;
        private IPAddress ipAddress;
        private int port;

        /// <summary>
        /// Initializes a new instance of the ClientSocket class.
        /// </summary>
        /// <param name="client">A client.</param>
        /// <param name="port">A port.</param>
        /// <param name="ip">The server IP address.</param>
        public ClientSocket(Client client, string ip = "127.0.0.1", int port = 8080)
        {
            this.client = client;
            this.port = port;
            ipAddress = IPAddress.Parse(ip);
        }

        /// <summary>
        /// Connect to server.
        /// </summary>
        public void Connect()
        {
            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(endPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Disconnect from server.
        /// </summary>
        public void Disconnect()
        {
            socket.Disconnect(true);
        }

        /// <summary>
        /// Send a message to server.
        /// </summary>
        /// <param name="msg">Message instance.</param>
        public void Send(Message msg)
        {
            byte[] clientMsg = new byte[50];
            byte[] message = new byte[1024];

            clientMsg = Encoding.ASCII.GetBytes(client.Name);
            message = Encoding.ASCII.GetBytes(msg.Text);

            socket.Send(clientMsg);
            socket.Send(message);
        }

        /// <summary>
        /// Get response from server.
        /// </summary>
        /// <returns>Returns answer from Server.</returns>
        public string Receive()
        {
            string answer = null;
            answer = ReceiveString();

            return answer;
        }

        private string ReceiveString()
        {
            string recvMsg = null;
            int bytesrcv;
            byte[] recvData = new byte[1024];

            if (socket.Available > 0)
            {
                bytesrcv = socket.Receive(recvData);
                recvMsg = Encoding.ASCII.GetString(recvData, 0, bytesrcv);
            }

            return recvMsg;
        }
    }
}
