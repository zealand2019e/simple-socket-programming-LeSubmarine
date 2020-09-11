using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace EchoServer
{
    public class Server
    {
        private static int totaltConnectionNo = 0;
        public void ServerStart()
        {
            int clientNo = 0;
            TcpClient connectionSocket;
            Thread.CurrentThread.Name = "Main";
            TcpListener serverSocket = new TcpListener(8888);
            serverSocket.Start();
            TaskFactory taskFactory = new TaskFactory();
            while (true)
            {
                connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("server activated");
                clientNo++;
                totaltConnectionNo++;
                taskFactory.StartNew(() => DoClient(connectionSocket,clientNo));
            }

            connectionSocket.Close();
            Console.WriteLine("connection socket closed");
            serverSocket.Stop();
            Console.WriteLine("server stopped");
        }   

        private void DoClient(TcpClient connection, int clientNo)
        {
            try
            {
                Stream ns = connection.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing
                int emptyMessages = 0;
                while (true)
                {
                    string message = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(message) && message != "")
                    {
                        Console.WriteLine("received message: " + message);
                        sw.WriteLine(message.ToUpper());
                        emptyMessages = 0;
                    }
                    else
                    {
                        emptyMessages++;
                        if (emptyMessages > 2)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Console.WriteLine($"Connection ended with clientNo{clientNo}");
                connection.Close();
                Console.WriteLine("Net stream closed");
                totaltConnectionNo--;
            }
        }
    }
}
