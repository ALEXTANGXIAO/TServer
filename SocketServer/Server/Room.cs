using SocketGameProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocketServer
{
    class Room
    {
        //public string roomname;//房间名字
        //public int maxnum;//最大人数
        //public int state;//当前状态

        private RoomPack roompack;

        public RoomPack GetRoomInfo
        {
            get
            {
                return roompack;
            }
        }

        private List<Client> clientList = new List<Client>();   //房间内所有的客户端

        public Room(Client client,RoomPack pack)
        {
            //this.roomname = pack.Roomname;
            //this.maxnum = pack.Maxnum;
            roompack = pack;
            clientList.Add(client);
            roompack.Curnum = clientList.Count;
        }
    }
}
