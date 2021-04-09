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
            if (client.GetUserData.Login(pack, client.GetMysqlConnect))
            {
                pack.Returncode = ReturnCode.Success;
                Debug.Log("登录成功！！！！");
                //client.GetUserInFo.UserName = pack.LoginPack.Username;
            }
            else
            {
                Debug.Log("登录失败！！！！");
                pack.Returncode = ReturnCode.Fail;
            }
            return pack;
        }
    }
}
