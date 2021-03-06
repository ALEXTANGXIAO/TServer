using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;
using SocketGameProtocol;

namespace ServerApp
{
    class Client
    {
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

        private Timer m_HeartBitTimer;
        public Client(Socket socket, Server server,UDPServer us)
        {
            userData = new UserData();
            message = new Message();

            GetUserInFo = new UserInFo();
            this.us = us;
            this.server = server;
            this.socket = socket;

            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            GetIpAddress(clientipe.Address.ToString());
            Debug.LogInfo(" [" + clientipe.Address.ToString() + clientAddress + "] Connected");
            clientip = "[" + clientipe.Address.ToString() + "]";
            ConnectMySql();
            StartReceive();

            InitHeartBeat();
        }

        private void InitHeartBeat()
        {
            m_HeartBitTimer = new Timer(HeartBeat, 0, 0, 15000);
            heartBeatPack.Requestcode = RequestCode.Heart;
            heartBeatPack.Actioncode = ActionCode.HeartBeat;
            heartBeatPack.Returncode = ReturnCode.Success;
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
            try
            {
                if (GetRoom != null)
                {
                    //客户端强制关闭，退出
                    GetRoom.Exit(server, this);
                }
                socket.Close();
                server.RemoveClient(this);

                if (m_HeartBitTimer != null)
                {
                    m_HeartBitTimer.Dispose();
                    m_HeartBitTimer = null;
                }

                CloseMySql();
                Debug.LogInfo(clientip + "--------------  心跳断开  --------------");
                Debug.Log(this.clientip + this.clientAddress + "断开连接");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        /// <summary>
        /// UDP发送
        /// </summary>
        /// <param name="pack"></param>
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
        private const double DIS_CONNECT_TIME = 15;
        private static readonly DateTime standardTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private static MainPack heartBeatPack = new MainPack();
        /// <summary>
        /// 心跳包
        /// </summary>
        private void HeartBeat(object state)
        {
            TimeSpan ts = DateTime.Now - standardTime;
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
                    //socket.Send(heartBytes);
                    Send(heartBeatPack);
                    //Debug.LogInfo(clientip + "-------------- 发送心跳包 --------------");
                }
                else
                {
                    //Debug.LogError(clientip + "-------------- 停止心跳包 --------------");
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

        public void CheckReceiveBuffer(MainPack pack)
        {
            if (pack == null)
            {
                return;   
            }

            if (pack.Actioncode == ActionCode.HeartBeat)
            {
                m_IsCheckHeart = false;
                m_TimeStamp = 0;
                Debug.LogInfo(clientip + "-------------- 接收心跳包 --------------");
            }
        }

        //SQL
        private const string m_source = "1.14.132.143";//106.52.118.65
        private const string m_userId = "test"; //tx
        private const string m_password = "txtx54TX";
        private const string connstr = "database=tgame;data source=" + m_source + "; User Id=" + m_userId + ";password=" + m_password + ";pooling=false;charset=utf8;port=3306";
        private static MySqlConnection mySqlConn;
        public MySqlConnection GetMysqlConnect
        {
            get { return mySqlConn; }
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
                mySqlConn.Close();
                Debug.LogError(clientip+"连接数据库失败");
                Debug.LogError(e);
                return;
            }
            Debug.LogWarning(clientip+"连接数据库成功");
        }

        public void CloseMySql()
        {
            if (mySqlConn != null)
            {
                mySqlConn.Close();
                mySqlConn = null;
            }
        }
    }
}
