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
            List<int> items = new List<int>();
            List<double> price = new List<double>();
            List<string> posAnswers = new List<string>() { "banana", "lemon", "apple", "milk", "meat" };
            string question = "Which item would you like?";
            question += " (";
            for (int i = 0; i < posAnswers.Count; i++)
            {
                question += posAnswers[i] + ", ";
            }
            question = question.Remove(question.Length - 1);
            question += ")";

            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine("received message: " + message);
                if (message != null)
                {
                    while (true)
                    {
                        sw.WriteLine($"Welcome to the shopping cart. {question}");

                        string answer = sr.ReadLine().ToLower();
                        if (answer != null)
                        {
                            for (int i = 0; i < posAnswers.Count; i++)
                            {
                                if (answer == posAnswers[i])
                                {
                                    price.Add(OneLineCalc.Program.ItemTypePrice(answer));
                                    break;
                                }
                            } 
                        }
                        else
                        {
                            break;
                        }
                    }
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
