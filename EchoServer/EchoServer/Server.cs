using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class Server
    {
        public static void ServerStart()
        {
            TcpListener serverSocket = new TcpListener(8888);

            serverSocket.Start();
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("server activated");


            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);

            StreamWriter sw = new StreamWriter(ns);

            sw.AutoFlush = true; // enable automatic flushing 



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
            ns.Close();
            Console.WriteLine("net stream closed");
            connectionSocket.Close();
            Console.WriteLine("connection socket closed");
            serverSocket.Stop();
            Console.WriteLine("server stopped");




        }
    }
}
