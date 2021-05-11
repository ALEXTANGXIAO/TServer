using System;
using System.Collections.Generic;
using System.Text;
using SocketGameProtocol;

namespace ServerApp
{
    class UserController:BaseController
    {
        public UserController()
        {
            requestCode = RequestCode.User;
        }

        public MainPack Register(Server server,Client client,MainPack pack)
        {
            if (client.GetUserData.Register(pack, client.GetMysqlConnect))
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
            if (client.GetUserData.Login(pack, client.GetMysqlConnect))
            {
                pack.Returncode = ReturnCode.Success;
                Debug.Log(client.clientip + pack.LoginPack.Username + "登录成功");
                client.Username = pack.LoginPack.Username;
                client.GetUserInFo.Username = pack.LoginPack.Username;
            }
            else
            {
                Debug.LogError(client.clientip + "登录失败！！！！");
                pack.Returncode = ReturnCode.Fail;
            }
            return pack;
        }
    }
}
