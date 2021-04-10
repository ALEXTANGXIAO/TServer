using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SocketGameProtocol;
using SocketServer.DAO;

namespace SocketServer
{
    class Server
    {
        private static Socket socket;

        private Thread ausThread;

        private List<Client> clientList = new List<Client>();
        private ControllerManager controllerManager;

        public Server(int port)
        {
            controllerManager = new ControllerManager(this);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(0);
            StartAccept();
        }

        void StartAccept()
        {
            socket.BeginAccept(AcceptCallback, null);
        }

        void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket client = socket.EndAccept(asyncResult);   //结束应答
            clientList.Add(new Client(client,this));
            StartAccept();
        }

        public void RemoveClient(Client client)
        {
            clientList.Remove(client);
        }

        public void Debuger()
        {
            
        }

        public void HandleRequest(MainPack pack,Client client)
        {
            controllerManager.HandleRequest(pack,client);
        }
    }
}
