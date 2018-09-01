using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SimpleShittyServer
{
    public class Server
    {
        private Socket socketServer;
        private Socket socketClient;
        public bool isConnected = false;
        protected string serverIPAddress = "";
        protected int serverPort = 0;
        public Server(string serverIPAddress, int serverPort)
        {
            socketServer = new Socket(SocketType.Stream, ProtocolType.Tcp);
            EndPoint ep = new IPEndPoint(IPAddress.Parse(serverIPAddress), serverPort);
            try
            {
                socketServer.Bind(ep);
                socketServer.Listen(1);
            }
            catch(SocketException err)
            {
                Console.WriteLine("Error while binding, try again later." + '\n');
                Console.WriteLine(err.Message + '\n');
                Environment.Exit(0);
            }
            
        }

        protected string GetServerIPAddress()
        {
            return serverIPAddress;
        }

        protected int GetServerPort()
        {
            return serverPort;
        }

        public void ConnectToClient()
        {
            socketClient = socketServer.Accept();
            isConnected = true;
        }

        public void GetData()
        {
            byte[] receivedBytes = new byte[1024];
            int nByteCount = socketClient.Receive(receivedBytes);

            string st = Encoding.GetEncoding(1251).GetString(receivedBytes, 0, nByteCount);
            Console.WriteLine("Data received: " + st + '\n');
        }

        public void DisconnectClient()
        {
            socketClient.Close();
            isConnected = false;
        }

        public void CloseServer()
        {
            if (isConnected)
            {
                DisconnectClient();
            }
            socketServer.Close();
        }
    }
}
