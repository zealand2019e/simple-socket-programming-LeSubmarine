using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();


            using (EchoClient client = new EchoClient())
            {
                string message = "Hello";
                client.Write(message);
                string received;
                while (true)
                {

                    received = client.Read();
                    DateTime time = DateTime.Now.AddSeconds(5);
                    while (string.IsNullOrWhiteSpace(message))
                    {
                        received = client.Read();
                        if (DateTime.Now > time)
                        {
                            Console.WriteLine("Server not responding.\nSending new message.");
                            client.Write(message);
                        }
                    }

                    Console.WriteLine(received);
                    message = Console.ReadLine();
                    client.Write(message);
                }
            }
        }
    }
}
