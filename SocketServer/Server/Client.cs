using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;
using SocketGameProtocol;
using SocketServer.DAO;

namespace SocketServer
{
    class Client
    {
        //106.52.118.65:3306
        private const string connstr = "database=tgame;data source=106.52.118.65;User Id=tx;password=123456;pooling=false;charset=utf8;port=3306";
        private MySqlConnection mySqlConn;


        private Socket socket;
        private Message message;
        private UserData userData;
        private Server server;

        public UserData GetUserData
        {
            get { return userData; }
        }

        public Client(Socket socket, Server server)
        {
            userData = new UserData();
            message = new Message();
            //mySqlConn = new MySqlConnection(connstr);
            ConnectMySql();
            this.server = server;
            this.socket = socket;

            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            Debug.LogInfo("[" + clientipe.Address.ToString() + "] Connected");
            

            StartReceive();
        }

        private void ConnectMySql()
        {
            try
            {
                mySqlConn = new MySqlConnection(connstr);

                mySqlConn.Open();
            }
            catch (Exception e)
            {
                Debug.LogError("连接数据库失败");
                Debug.LogError(e);
                return;
            }
            //Debug.LogError("连接数据库成功");
        }

        void StartReceive()
        {
            socket.BeginReceive(message.Buffer, message.StartIndex,message.Remsize, SocketFlags.None, ReceiveCallback, null);
        }

        void ReceiveCallback(IAsyncResult asyncResult)
        {
            try
            {
                if (socket == null || socket.Connected == false)
                {
                    return;
                }

                int Length = socket.EndReceive(asyncResult);

                if (Length == 0)
                {
                    return;
                }

                message.ReadBuffer(Length, HandleRequest);

                StartReceive();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        public void Send(MainPack pack)
        {
            socket.Send(Message.PackData(pack));
        }

        private void HandleRequest(MainPack pack)
        {
            server.HandleRequest(pack,this);
        }

        public bool Register(MainPack pack)
        {
            return GetUserData.Register(pack, mySqlConn);
        }

        private void Close()
        {
            server.RemoveClient(this);
            socket.Close();
            mySqlConn.Close();
        }
    }
}
