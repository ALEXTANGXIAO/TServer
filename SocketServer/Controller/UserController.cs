using System;
using System.Collections.Generic;
using System.Text;
using SocketGameProtocol;

namespace SocketServer
{
    class UserController:BaseController
    {
        public UserController()
        {
            requestCode = RequestCode.User;
        }

        public MainPack Register(Server server,Client client,MainPack pack)
        {
            if (client.Register(pack))
            {
                pack.Returncode = ReturnCode.Success;
            }
            else
            {
                pack.Returncode = ReturnCode.Fail;
            }
            return pack;
        }

        public MainPack Login(Server server, Client client, MainPack pack)
        {
            return null;
        }
    }
}
