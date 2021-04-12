using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SocketGameProtocol;

namespace SocketServer
{
    class ControllerManager
    {
        private Dictionary<RequestCode,BaseController> controllerDic = new Dictionary<RequestCode, BaseController>();

        private Server server;
        public ControllerManager(Server server)
        {
            this.server = server;
            UserController userController = new UserController();
            controllerDic.Add(userController.GetRequestCode,userController);

            RoomController roomController = new RoomController();
            controllerDic.Add(roomController.GetRequestCode, roomController);
        }

        public void HandleRequest(MainPack pack,Client client)
        {
            if (client == null)
            {
                Debug.LogError("Client为空");
            }

            if (controllerDic.TryGetValue(pack.Requestcode, out BaseController controller))
            {
                string methodname = pack.Actioncode.ToString();                 //ActionCode的string反射拿到Controller的方法
                MethodInfo method = controller.GetType().GetMethod(methodname);
                if (method == null)
                {
                    Debug.LogError(client.clientip + "没有对应Method");
                    return;
                }
                object[] obj = new object[]{server, client, pack};
                object ret = method.Invoke(controller, obj);
                if (ret != null)
                {
                    client.Send(ret as MainPack);
                }
            }
            else
            {
                Debug.LogError(client.clientip +"没有对应Controller的处理" + pack.Requestcode + pack);
            }
        }
    }
}
