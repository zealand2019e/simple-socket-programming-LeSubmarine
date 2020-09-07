using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    public class EchoClient
    {
        private TcpClient _clientSocket;
        private Stream _ns;
        private StreamReader _sr;
        private StreamWriter _sw;

        public EchoClient()
        {
            _clientSocket = new TcpClient("localhost",8888);



            _ns = _clientSocket.GetStream(); //provides a Stream 

            _sr = new StreamReader(_ns);
            
            _sw = new StreamWriter(_ns);

            _sw.AutoFlush = true; // enable automatic flushing 
        }

        public void Write(string message)
        {
            _sw.WriteLine(message);

        }

        public string Read()
        {
            string a = _sr.ReadLine();
            return a; //_sr.ReadToEnd();
        }
    }
}
