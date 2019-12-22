using System.Threading;
using NUnit.Framework;
using ClientLib;
using System;

namespace Task4.Tests
{
    [TestFixture]
    public class Tests
    {
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
                actString = clientSocket.Receive();
                clientSocket.Close();
                waitClientReceive = false;
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
                server.Send(messages);
                server.Close();
            };

            Thread serverThread = new Thread(new ThreadStart(runServer));
            Thread clientThread = new Thread(new ThreadStart(runClient));

            serverThread.Start();
            clientThread.Start();

            while (waitClientReceive);

            Assert.NotNull(actString);
            Assert.AreEqual(expString, actString);

            serverThread.Abort();
            clientThread.Abort();
        }

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
                Message message = new Message("Hello User", client);
                clientSocket.Connect();
                clientSocket.Send(message);
                actString = clientSocket.Receive();
                clientSocket.Close();
                waitClientReceive = false;
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
                server.Send(messages);
                server.Close();
            };

            Thread serverThread = new Thread(new ThreadStart(runServer));
            Thread clientThread = new Thread(new ThreadStart(runClient));

            serverThread.Start();
            clientThread.Start();

            while (waitClientReceive);

            Assert.AreEqual(expString, actString);

            serverThread.Abort();
            clientThread.Abort();
        }
    }
}
