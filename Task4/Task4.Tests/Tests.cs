using System.Threading;
using NUnit.Framework;
using ClientLib;
using System;

namespace Task4.Tests
{
    /// <summary>
    /// Class for testing classes
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Testing Response from Server
        /// </summary>
        [Test]
        public void TestServerResponse()
        {
            string expString = "Text: Hello User; Client: Alexis - Succesfully";
            string actString = null;
            bool waitClientReceive = true;

            Action runClient = () =>
            {
                Client client = new Client("Alexis");
                ClientSocket clientSocket = new ClientSocket(client);
                Message message = new Message("Hello User", client);
                clientSocket.Connect();
                clientSocket.Send(message);
                while (waitClientReceive) ;
                actString = clientSocket.Receive();
                clientSocket.Close();
            };

            Action runServer = () =>
            {
                Server server = new Server(5, 8080, "127.0.0.1");
                try
                {
                    server.WaitClientConnection();
                }
                catch { }
                Message messages = server.Receive();
                waitClientReceive = false;
                server.Send(messages);
            };

            Thread serverThread = new Thread(new ThreadStart(runServer));
            Thread clientThread = new Thread(new ThreadStart(runClient));

            serverThread.Start();
            clientThread.Start();

            Thread.Sleep(2000);

            Assert.NotNull(actString);
            Assert.AreEqual(expString, actString);
        }

        /// <summary>
        /// Testing transliting message
        /// </summary>
        [Test]
        public void TestTranslit()
        {
            string expString = "Text: Shishka Kharizma; Client: Alexis - Succesfully";
            string actString = null;
            bool waitClientReceive = true;

            Action runClient = () =>
            {
                Client client = new Client("Alexis");
                ClientSocket clientSocket = new ClientSocket(client);
                Message message = new Message("Шишка Харизма", client);
                clientSocket.Connect();
                clientSocket.Send(message);
                while (waitClientReceive) ;
                actString = clientSocket.Receive();
                clientSocket.Close();
            };

            Action runServer = () =>
            {
                Server server = new Server(5, 8080, "127.0.0.1");
                try
                {
                    server.WaitClientConnection();
                }
                catch { }
                Message messages = server.Receive();
                waitClientReceive = false;
                server.Send(messages);
            };

            Thread serverThread = new Thread(new ThreadStart(runServer));
            Thread clientThread = new Thread(new ThreadStart(runClient));

            serverThread.Start();
            clientThread.Start();

            Thread.Sleep(2000);

            Assert.NotNull(actString);
            Assert.AreEqual(expString, actString);
        }
    }
}
