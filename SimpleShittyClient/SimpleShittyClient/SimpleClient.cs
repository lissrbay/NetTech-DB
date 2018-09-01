using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SimpleShittyClient
{
    class SimpleClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IP-address of server: " + '\n');
            string serverIPAddress = Console.ReadLine();
            Console.WriteLine("Port:" + '\n'); 
            int serverPort = Convert.ToInt16(Console.ReadLine());
            Client socketServer = new Client();

            socketServer.ConnectToServer(serverIPAddress, serverPort);
            socketServer.SendData();

            socketServer.CloseConnection();
        }
    }
}
