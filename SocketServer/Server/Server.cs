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

        private List<Client> clientList = new List<Client>(); //世界消息在ClientList发送

        private List<Room> roomList = new List<Room>();     //房间消息在房间list发送

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

        public ReturnCode CreateRoom(Client client,MainPack pack)
        {
            try
            {
                Room room = new Room(client, pack.Roompack[0]);
                roomList.Add(room);
                return ReturnCode.Success;
            }
            catch
            {
                return ReturnCode.Fail;
            }
        }

        public MainPack FindRoom()
        {
            MainPack pack = new MainPack();
            pack.Actioncode = ActionCode.FindRoom;
            try
            {
                if(roomList.Count == 0)
                {
                    pack.Returncode = ReturnCode.NoneRoom;
                    return pack;
                }
                foreach (Room room in roomList)
                {
                    //if(room.GetRoomInfo.State!= 0)
                    //{
                    //    continue;
                    //}
                    pack.Roompack.Add(room.GetRoomInfo);
                }
                pack.Returncode = ReturnCode.Success;
            }
            catch
            {
                pack.Returncode = ReturnCode.Fail;
            }

            return pack;
        }
    }
}
