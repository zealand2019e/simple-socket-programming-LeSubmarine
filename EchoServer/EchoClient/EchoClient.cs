using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoClient
{
    public class EchoClient : IDisposable
    {
        private TcpClient _clientSocket;
        private Stream _ns;
        private StreamReader _sr;
        private StreamWriter _sw;

        public EchoClient() 
        { 
            _clientSocket = new TcpClient("192.168.24.183",7777);

            
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
            return _sr.ReadLine();
        }

        //public async Task<string> AsyncRead()
        //{
        //    TaskFactory taskFactory = new TaskFactory();
        //    List<Task<string>> returnStrings = new List<Task<string>>();
        //    string returnString;
        //    while (true)
        //    {
        //        returnStrings.Add(taskFactory.StartNew(() => ReadLineAsync());
        //    }

        //    return returnString; //_sr.ReadToEnd();
        //}

        //private async Task<string> ReadLineAsync()
        //{
        //    string returnString;
        //    returnString = _sr.ReadLine();
        //    return returnString;
        //}

        public void Dispose()
        {
            _clientSocket?.Dispose();
            _ns?.Dispose();
            _sr?.Dispose();
            _sw?.Dispose();
        }
    }
}
