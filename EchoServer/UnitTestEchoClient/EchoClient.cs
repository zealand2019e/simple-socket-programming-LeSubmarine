using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EchoServer;

namespace UnitTestEchoClient
{
    [TestClass]
    public class EchoClient
    {
        private EchoClient client;
        [ClassInitialize]
        public void Start()
        {
            Server.ServerStart();
        }
        [TestMethod]
        public void TestMethodConnection()
        {
        }
    }
}
