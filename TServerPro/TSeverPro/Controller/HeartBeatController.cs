using System;
using System.Collections.Generic;
using System.Text;
using SocketGameProtocol;

namespace SocketServer
{
    class HeartBeatController : BaseController
    {
        public HeartBeatController()
        {
            requestCode = RequestCode.Heart;
        }

        public MainPack HeartBeat(Server server, Client client, MainPack pack)
        {
            client.CheckReceiveBuffer(pack);
            return null;
        }
    }
}
