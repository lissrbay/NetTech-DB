using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SimpleShittyServer
{
    class SimpleServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IP-address of server: " + '\n');
            string serverIPAddress = Console.ReadLine();
            Console.WriteLine("Port:" + '\n');
            int serverPort = Convert.ToInt16(Console.ReadLine());
            Server socketServer = new Server(serverIPAddress, serverPort);

            socketServer.ConnectToClient();
            socketServer.GetData();

            socketServer.CloseServer();
        }
    }
}