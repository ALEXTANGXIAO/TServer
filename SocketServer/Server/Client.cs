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

        private Socket udpClient;
        private EndPoint remoteEp;
        public UDPServer us;
        private Socket socket;
        private Message message;
        private UserData userData;
        private Server server;
        public string Username { get; set; }
        public Room GetRoom { get; set; }

        public EndPoint IEP
        {
            get
            {
                return remoteEp;
            }
            set
            {
                remoteEp = value;
            }
        }


        public string clientip;
        public string clientAddress = "";

        public UserInFo GetUserInFo
        {
            get;
            set;
        }

        public class UserInFo
        {
            public string Username
            {
                get; set;
            }

            public int HP
            {
                set;
                get;
            }

            public PosPack Pos
            {
                get;
                set;
            }
        }

        public UserData GetUserData
        {
            get { return userData; }
        }

        public MySqlConnection GetMysqlConnect
        {
            get { return mySqlConn; }
        }

        public Client(Socket socket, Server server,UDPServer us)
        {
            userData = new UserData();
            message = new Message();
            //mySqlConn = new MySqlConnection(connstr);
            ConnectMySql();
            GetUserInFo = new UserInFo();
            this.us = us;
            this.server = server;
            this.socket = socket;

            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            GetIpAddress(clientipe.Address.ToString());
            Debug.LogInfo("[" + clientipe.Address.ToString() + "] Connected");
            clientip = "[" + clientipe.Address.ToString() + "]";
            StartReceive();
        }

        private void GetIpAddress(string ip)
        {
            string jsonString = Util.Post("http://whois.pconline.com.cn/ipJson.jsp?ip="+ ip+"&json=true");
            var jsonData = TJson.Deserialize(jsonString);
            if (jsonData != null)
            {
                var dictionary = jsonData.DictionaryData;
                object b;
                dictionary.TryGetValue("addr", out b);
                clientAddress = b.ToString();
                Debug.Log(b.ToString());
            }
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
            if (socket == null || socket.Connected == false)
            {
                return;
            }

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
                    Close();
                    return;
                }

                message.ReadBuffer(Length, HandleRequest);

                StartReceive();
            }
            catch (Exception e)
            {
                Debug.LogError(clientip + e);
                Close();
            }
        }

        public void Send(MainPack pack)
        {
            if (socket == null || socket.Connected == false) return;
            try
            {
                socket.Send(Message.PackData(pack));
            }
            catch
            {

            }
        }

        private void HandleRequest(MainPack pack)
        {
            server.HandleRequest(pack,this);
        }

        private void Close()
        {
            if (GetRoom != null)
            {
                Debug.Log(this.clientAddress + this.clientip + "断开连接");
                //客户端强制关闭，退出
                GetRoom.Exit(server,this);
            }
            socket.Close();
            mySqlConn.Close();
            server.RemoveClient(this);
        }

        public void SendTo(MainPack pack)
        {
            if (IEP == null) return;
            us.SendTo(pack, IEP);
        }

        public void UpPos(MainPack pack)
        {
            GetUserInFo.Pos = pack.Playerpack[0].PosPack;
        }
    }
}
