using System;
using System.IO;
using System.Net.Sockets;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server newServer = new Server();
            newServer.ServerStart();
            
        }
    }
}
