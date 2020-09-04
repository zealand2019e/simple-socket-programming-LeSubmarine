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

            while (true)
            {

                string message = Console.ReadLine();
                message = client.WriteRead(message);
                Console.WriteLine(message);
            }
        }
    }
}
