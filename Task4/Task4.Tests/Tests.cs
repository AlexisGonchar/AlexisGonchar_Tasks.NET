using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ClientLib;
using ServerLib;

namespace Task4.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            string msg = "";
            Client client = new Client("Bob");
            Server server = new Server();

            Thread th = new Thread(delegate () { client.SendMessage("s"); });
            Thread th1 = new Thread(delegate() {msg = server.Listen(10); });

            th1.Start();
            th.Start();


            Assert.AreEqual(msg, "s");
        }
    }
}
