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
        private UDPServer us;
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
            Debug.LogInfo("TCP服务已启动...  Port:" + port);
            us = new UDPServer(port + 1, this, controllerManager);
        }

        ~Server()
        {
            if (ausThread != null)
            {
                ausThread.Abort();
                ausThread = null;
            }

        }

        void StartAccept()
        {
            socket.BeginAccept(AcceptCallback, null);
        }

        void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket client = socket.EndAccept(asyncResult);   //结束应答
            clientList.Add(new Client(client,this,us));
            StartAccept();
        }

        public void RemoveClient(Client client)
        {
            clientList.Remove(client);
            client = null;
            Memory.ClearMemory();
        }

        public void HandleRequest(MainPack pack,Client client)
        {
            controllerManager.HandleRequest(pack,client);
        }

        public MainPack CreateRoom(Client client,MainPack pack)
        {
            try
            {
                Room room = new Room(client, pack.Roompack[0],this); //创建一个房间
                roomList.Add(room);
                foreach (var p in room.GetPlayerInfos())
                {
                    pack.Playerpack.Add(p);
                }
                pack.Returncode = ReturnCode.Success;
                return pack;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                pack.Returncode = ReturnCode.Fail;
                return pack;
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

        public MainPack JoinRoom(Client client,MainPack pack)
        {
            foreach (var room in roomList)
            {
                if (room.GetRoomInfo.Roomname.Equals(pack.Str))
                {
                    //存在房间
                    //room State为0则是等待状态可以加入房间
                    if (room.GetRoomInfo.State == (int)RoomState.Waiting)
                    {
                        //可以加入房间
                        room.Join(client);
                        pack.Roompack.Add(room.GetRoomInfo);
                        foreach (var p in room.GetPlayerInfos())
                        {
                            pack.Playerpack.Add(p);
                        }

                        pack.Returncode = ReturnCode.Success;
                        return pack;
                    }
                    else
                    {
                        //房间不可加入
                        pack.Returncode = ReturnCode.Fail;
                        return pack;
                    }
                }
            }
            //没有此房间
            pack.Returncode = ReturnCode.NoneRoom;

            return pack;
        }

        public MainPack ExitRoom(Client client, MainPack pack)
        {
            if (client.GetRoom == null)
            {
                //非正常游戏
                pack.Returncode = ReturnCode.Fail;
                return pack;
            }

            client.GetRoom.Exit(this,client);
            pack.Returncode = ReturnCode.Success;
            return pack;
        }

        public void RemoveRoom(Room room)
        {
            if (roomList.Contains(room))
            {
                roomList.Remove(room);
            }
            room = null;
            Memory.ClearMemory();
        }

        public void Chat(Client client, MainPack pack)
        {
            try
            {
                pack.Str = client.Username + ":" + pack.Str;
                //Debug.Log(pack);
                if (client.GetRoom == null)
                {
                    Debug.LogError(client.Username+"没有房间");
                    return;
                }
                pack.Returncode = ReturnCode.Success;
                client.GetRoom.Broadcast(client, pack);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        /// <summary>
        /// 世界广播消息
        /// </summary>
        /// <param name="Myclient"></param>
        /// <param name="pack"></param>
        public void BroadcastWorld(MainPack pack)
        {
            foreach (Client client in clientList)
            {
                client.Send(pack);
            }
        }

        public Client ClientFromUserName(string user)
        {
            foreach (Client c in clientList)
            {
                if (c.GetUserInFo.Username == user)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
