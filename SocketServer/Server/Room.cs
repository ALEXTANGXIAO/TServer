using SocketGameProtocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Google.Protobuf.Collections;

namespace SocketServer
{
    public enum RoomState
    {
        Waiting = 0,
        MaxPlayer = 1,
        Started = 2
    }

    class Room
    {
        private RoomPack roompack;

        public RoomPack GetRoomInfo
        {
            get
            {
                roompack.Curnum = clientList.Count;
                return roompack;
            }
        }

        private List<Client> clientList = new List<Client>();   //房间内所有的客户端

        public Room(Client client,RoomPack pack)
        {
            roompack = pack;
            clientList.Add(client);
            client.GetRoom = this;
            //roompack.Curnum = clientList.Count;
        }

        public RepeatedField<PlayerPack> GetPlayerInfos()
        {
            RepeatedField<PlayerPack> packlist = new RepeatedField<PlayerPack>();
            foreach (Client client in clientList)
            {
                PlayerPack pack = new PlayerPack();
                pack.Playername = client.Username;
                packlist.Add(pack);
            }

            return packlist;
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="Myclient"></param>
        /// <param name="pack"></param>
        public void Broadcast(Client Myclient,MainPack pack)
        {
            foreach (Client client in clientList)
            {
                //if (Myclient.Equals(client))
                //{
                //    continue;
                //}
                client.Send(pack);
            }
        }

        public void Join(Client client)
        {
            clientList.Add(client);
            if (clientList.Count >= roompack.Maxnum)
            {
                //满人了
                roompack.State = (int)RoomState.MaxPlayer;
            }
            client.GetRoom = this;
            MainPack pack = new MainPack();
            pack.Actioncode = ActionCode.PlayerList;
            foreach (var player in GetPlayerInfos())
            {
                pack.Playerpack.Add(player);
            }
            Broadcast(client,pack);
        }

        public void Exit(Server server, Client client)
        {
            MainPack pack = new MainPack();

            //if (roompack.State == (int)RoomState.Started)
            //{
                
            //}
            //else
            //{

            //}

            if (client == clientList[0])
            {
                //房主离开了,解散房间
                client.GetRoom = null;
                pack.Actioncode = ActionCode.Exit;
                Broadcast(client, pack);
                server.RemoveRoom(this);
                return;
            }
            clientList.Remove(client);
            roompack.State = (int)RoomState.Waiting;
            client.GetRoom = null;
            pack.Actioncode = ActionCode.PlayerList;
            foreach (var player in GetPlayerInfos())
            {
                pack.Playerpack.Add(player);
            }
            Broadcast(client, pack);
        }

        public ReturnCode StartGame(Client client)
        {
            if (client != clientList[0])
            {
                return ReturnCode.Fail; //不是房主
            }
            roompack.State = 2;
            Thread starttime = new Thread(Time);
            starttime.Start();
            Debug.Log(roompack + "开始游戏");
            return ReturnCode.Success;
        }

        private void Time()
        {
            MainPack pack = new MainPack();
            pack.Actioncode = ActionCode.Chat;
            pack.Str = "房主已启动游戏...";
            Broadcast(null, pack);
            Thread.Sleep(1000);
            for (int i = 5; i > 0; i--)
            {
                pack.Str = i.ToString();
                Broadcast(null, pack);
                Thread.Sleep(1000);
            }

            pack.Actioncode = ActionCode.Starting;

            foreach (var client in clientList)
            {
                PlayerPack player = new PlayerPack();
                player.Playername = client.Username;
                pack.Playerpack.Add(player);
            }
            Broadcast(null, pack);
        }

        //public void ExitGame(Client client)
        //{
        //    MainPack pack = new MainPack();
        //    if (client == clientList[0])
        //    {
        //        //房主退出
        //        pack.Actioncode = ActionCode.ExitGame;
        //        pack.Str = "r";
        //        Broadcast(client, pack);
        //        server.RemoveRoom(this);
        //        client.GetRoom = null;
        //    }
        //    else
        //    {
        //        //其他成员退出
        //        clientList.Remove(client);
        //        client.GetRoom = null;
        //        pack.Actioncode = ActionCode.UpCharacterList;
        //        foreach (var VARIABLE in clientList)
        //        {
        //            PlayerPack playerPack = new PlayerPack();
        //            playerPack.Playername = VARIABLE.GetUserInFo.UserName;
        //            playerPack.Hp = VARIABLE.GetUserInFo.HP;
        //            pack.Playerpack.Add(playerPack);
        //        }
        //        pack.Str = client.GetUserInFo.UserName;
        //        Broadcast(client, pack);
        //    }
        //}
    }
}
