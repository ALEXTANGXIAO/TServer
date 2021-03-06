using SocketGameProtocol;
using System.Net;

namespace ServerApp
{
    class GameController : BaseController
    {
        public GameController()
        {
            requestCode = RequestCode.Game;
        }


        public MainPack ExitGame(Server server, Client client, MainPack pack)
        {
            if (client == null)
            {
                return null;
            }
            client.GetRoom.ExitGame(client);
            return null;
        }

        //public MainPack UpPos(Server server, Client client, MainPack pack)
        //{
        //    client.GetRoom.Broadcast(client, pack);
        //    //client.UpPos(pack);//更新位置信息
        //    return null;
        //}

        public MainPack UpPos(Client client, MainPack pack)
        {
            if (client == null)
            {
                return null;
            }

            if (client.GetRoom == null)
            {
                return null;
            }

            client.GetRoom.BroadcastTo(client, pack);
            client.UpPos(pack);//更新位置信息
            return null;
        }

        //public MainPack Fire(Server server, Client client, MainPack pack)
        //{
        //    client.GetRoom.BroadcastTo(client, pack);
        //    return null;
        //}

        //public MainPack Damage(Server server, Client client, MainPack pack)
        //{
        //    client.GetRoom.Damage(pack, client);
        //    return null;
        //}
    }
}