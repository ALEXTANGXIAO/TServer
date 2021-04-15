using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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


        private Timer m_HeartBitTimer;
        public Client(Socket socket, Server server,UDPServer us)
        {
            userData = new UserData();
            message = new Message();
            ConnectMySql();
            GetUserInFo = new UserInFo();
            this.us = us;
            this.server = server;
            this.socket = socket;

            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            GetIpAddress(clientipe.Address.ToString());
            Debug.LogInfo(clientAddress +" [" + clientipe.Address.ToString() + "] Connected");
            clientip = "[" + clientipe.Address.ToString() + "]";
            StartReceive();

            //m_HeartBitTimer = new Timer(HeartBit, 0, 0, 15000);
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
                //Debug.Log(b.ToString());
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

                if (Length <= 0)
                {
                    Close();
                    return;
                }

                //if (Length == 1)
                //{
                //    //心跳包 
                //    CheckReceiveBuffer();
                //    StartReceive();
                //    return;
                //}

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

            if(m_HeartBitTimer != null)
            {
                m_HeartBitTimer.Dispose();
                m_HeartBitTimer = null;
            }
            Debug.LogInfo(clientip + "--------------  心跳断开  --------------");
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


        private bool m_IsCheckHeart = false;
        private double m_TimeStamp = 0;
        private const double DIS_CONNECT_TIME = 30;
        private byte[] heartBytes = new byte[1]{6};
        /// <summary>
        /// 心跳包
        /// </summary>
        /// <param name="state"></param>
        private void HeartBit(object state)
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (m_TimeStamp == 0)
            {
                m_TimeStamp = ts.TotalSeconds;
            }

            if (ts.TotalSeconds - m_TimeStamp > DIS_CONNECT_TIME)
            {
                if (!m_IsCheckHeart)
                {
                    m_IsCheckHeart = true;
                    m_TimeStamp = ts.TotalSeconds;
                    socket.Send(heartBytes);
                    Debug.LogInfo(clientip + "-------------- 发送心跳包 --------------");
                }
                else
                {
                    Close();
                }
            }
        }


        private void CheckReceiveBuffer()
        {
            m_IsCheckHeart = false;
            m_TimeStamp = 0;
            Debug.LogInfo(clientip + "-------------- 接收心跳包 --------------");
        }
    }
}
