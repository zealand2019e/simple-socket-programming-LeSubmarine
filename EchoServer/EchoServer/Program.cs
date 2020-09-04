using System;
using System.IO;
using System.Net.Sockets;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.ServerStart();
            //Console.ReadLine();

            //TcpClient clientSocket = new TcpClient("localhost", 8888);



            //Stream ns = clientSocket.GetStream();  //provides a Stream 

            //StreamReader sr = new StreamReader(ns);

            //StreamWriter sw = new StreamWriter(ns);

            //sw.AutoFlush = true; // enable automatic flushing 


            //Server.ServerStart();
            //string message = Console.ReadLine();

            //sw.WriteLine(message);

            //string serverAnswer = sr.ReadLine();
            //Console.WriteLine(serverAnswer);
        }
    }
}
