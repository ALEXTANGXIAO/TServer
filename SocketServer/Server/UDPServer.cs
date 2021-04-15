using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SocketGameProtocol;

namespace SocketServer
{
    class UDPServer
    {
        Socket udpServer;//udpsocket
        IPEndPoint bindEP;//本地监听ip
        EndPoint remoteEP;//远程ip

        Server server;

        ControllerManager controllerManager;


        Byte[] buffer = new Byte[1024];//消息缓存

        Thread receiveThread;//接收线程

        public UDPServer(int port, Server server, ControllerManager controllerManager)
        {
            this.server = server;
            this.controllerManager = controllerManager;
            udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            bindEP = new IPEndPoint(IPAddress.Any, port);
            remoteEP = (EndPoint)bindEP;
            udpServer.Bind(bindEP);
            receiveThread = new Thread(ReceiveMsg);
            receiveThread.Start();
            Debug.LogInfo("UDP服务已启动...  Port:" + port);
        }

        ~UDPServer()
        {
            if (receiveThread != null)
            {
                receiveThread.Abort();
                receiveThread = null;
            }
        }

        public void ReceiveMsg()
        {
            try
            {
                while (true)
                {
                    int len = udpServer.ReceiveFrom(buffer, ref remoteEP);
                    MainPack pack = (MainPack)MainPack.Descriptor.Parser.ParseFrom(buffer, 0, len);
                    Handlerequest(pack, remoteEP);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }


        public void Handlerequest(MainPack pack, EndPoint iPEndPoint)
        {

            Client client = server.ClientFromUserName(pack.User);
            if (client == null)
            {
                return;
            }
            if (client.IEP == null)
            {
                client.IEP = iPEndPoint;
            }
            //Debug.Log(client.IEP.ToString());
            controllerManager.HandleRequest(pack, client, true);
        }

        public void SendTo(MainPack pack, EndPoint point)
        {
            byte[] buff = Message.PackDataUDP(pack);
            udpServer.SendTo(buff, buff.Length, SocketFlags.None, point);
        }
    }
}
