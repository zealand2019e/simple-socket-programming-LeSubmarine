using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    public class Server
    {
        private TcpListener serverSocket;
        private TcpClient connectionSocket;
        private StreamReader sr;
        private StreamWriter sw;
        private Stream ns;

        public void ServerStart()
        {
            serverSocket = new TcpListener(8888);
            serverSocket.Start();
            connectionSocket = serverSocket.AcceptTcpClient(); 
            Console.WriteLine("server activated");
            ns = connectionSocket.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing
            Run();
            



        }

        private void Run()
        {
            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine("received message: " + message);
                if (message != null)
                {
                    sw.WriteLine(message.ToUpper());
                }
                if (message == "break")
                {
                    break;
                }
            }
            Stop();
        }

        private void Stop()
        {
            ns.Close();
            Console.WriteLine("net stream closed");
            connectionSocket.Close();
            Console.WriteLine("connection socket closed");
            serverSocket.Stop();
            Console.WriteLine("server stopped");
        }
    }
}
