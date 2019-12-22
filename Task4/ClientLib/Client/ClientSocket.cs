using System;
using System.Collections.Generic;
using System.Text;
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

        private ClientMessageHandler handler;

        Dictionary<char, string> RUSTOENG = new Dictionary<char, string>()
        {
            {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"}, {'е', "e"}, {'ё', "e"},
            {'ж', "zh"}, {'з', "z"}, {'и', "i"}, {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"},
            {'н', "n"}, {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"}, {'у', "u"},
            {'ф', "f"}, {'х', "kh"}, {'ц', "ts"}, {'ч', "ch"}, {'ш', "sh"}, {'щ', "sch"}, {'ь', ""},
            {'ы', "y"}, {'ъ', ""}, {'э', "e"}, {'ю', "yu"}, {'я', "y"}
        };

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
            SetEvent();
        }

        private void SetEvent()
        {
            handler = new ClientMessageHandler();
            handler.MsgEvent += (string msg) =>
            {
                string text = "";
                foreach(char letter in msg)
                {
                    char biglet = Char.ToLower(letter);
                    if (RUSTOENG.ContainsKey(letter))
                    {
                        text += RUSTOENG[letter];
                    }
                    else if (RUSTOENG.ContainsKey(biglet))
                    {
                        text += Char.ToUpper(RUSTOENG[biglet][0]) +
                                RUSTOENG[biglet].Substring(1);
                    }
                    else
                    {
                        text += letter;
                    } 
                }
                msg = text;
                return msg;
            };
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

            clientMsg = Encoding.UTF8.GetBytes(client.Name);
            message = Encoding.UTF8.GetBytes(msg.Text);

            socket.Send(clientMsg);
            socket.Send(message);
        }

        /// <summary>
        /// Get response from server.
        /// </summary>
        /// <returns>Returns answer from Server.</returns>
        public string Receive()
        {
            string answer = ReceiveString();
            answer = handler.OnLoadMessage(answer);
            return answer;
        }

        private string ReceiveString()
        {
            string recvMsg = null;
            int bytesrcv;
            byte[] recvData = new byte[1024];
            do
            {
                bytesrcv = socket.Receive(recvData);
                recvMsg = Encoding.UTF8.GetString(recvData, 0, bytesrcv);
            }
            while (socket.Available>0);

            return recvMsg;
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void Close()
        {
            socket.Close();
        }
    }
}
