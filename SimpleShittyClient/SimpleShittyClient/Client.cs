using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SimpleShittyClient
{
    class Client
    {
        private Socket socketServer;

        public Client()
        {
            socketServer = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public void ConnectToServer(string serverIPAddress, int serverPort)
        {
            EndPoint socketEndPoint = new IPEndPoint(IPAddress.Parse(serverIPAddress), serverPort);
            try
            {
                socketServer.Connect(socketEndPoint);
            }
            catch (SocketException err)
            {
                Console.WriteLine("Error while connecting, try again later." + '\n');
                Console.WriteLine(err.Message + '\n');
                Environment.Exit(0);
            }
        }

        public void SendData()
        {
            Console.WriteLine("Sending data: " + '\n');
            string st = Console.ReadLine();
            byte[] sendingBytes = Encoding.GetEncoding(1251).GetBytes(st);
            socketServer.Send(sendingBytes);
        }

        public void CloseConnection()
        {
            socketServer.Close();
        }
    }
}

