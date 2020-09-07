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

            
            EchoClient client = new EchoClient();
            string message = "Hello";
            client.Write(message);
            while (true)
            {

                message = client.Read();
                while (true)
                {
                    if (message == "" || message == null)
                    {
                        message = client.Read();
                        
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine(message);
                message = Console.ReadLine();
                client.Write(message);
            }
        }
    }
}
