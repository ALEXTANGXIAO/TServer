using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace SocketServer
{

    class Program
    {

        static void Main(string[] args)
        {
            Debug.Log("===========START SOCKET SERVER============");
            Server server = new Server(6666);
            Console.Read();
        }


        //    private static string connstr = "database=tgame;data source=106.52.118.65;User Id=tx;password=123456;pooling=false;charset=utf8;port=3306";
        //    private static MySqlConnection mySqlConn;
        //    private static void ConnectMySql()
        //    {
        //        try
        //        {
        //            mySqlConn = new MySqlConnection(connstr);

        //            mySqlConn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.LogError("连接数据库失败");
        //            Debug.LogError(e);
        //            return;
        //        }
        //        Debug.LogError("连接数据库成功");
        //    }
        //}
        //class Program
        //{

        //    //==========================
        //    private static MySqlConnection mySqlConn;
        //    //106.52.118.65:3306
        //    private static string connstr = "database=tgame;data source=106.52.118.65;User Id=tx;password=123456;pooling=false;charset=utf8;port=3306";

        //    private static void ConnectMySql()
        //    {
        //        try
        //        {
        //            mySqlConn = new MySqlConnection(connstr);

        //            mySqlConn.Open();
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.LogError("连接数据库失败");
        //            Debug.LogError(e);
        //        }

        //        Debug.Log("CONNECT MYSQL SUCCESS!");
        //    }

        //    //==========================

        //    private static Socket socket;
        //    private static byte[] buffer = new byte[1024];
        //    static void Main(string[] args)
        //    {
        //        Debug.Log("===========START SOCKET SERVER============");
        //        ConnectMySql();
        //        socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        //        socket.Bind(new IPEndPoint(IPAddress.Any, 6666));
        //        socket.Listen(0);
        //        StartAccept();
        //        Console.Read();
        //    }

        //    static void StartAccept()
        //    {
        //        socket.BeginAccept(AcceptCallback, null);
        //    }

        //    static void AcceptCallback(IAsyncResult asyncResult)
        //    {
        //        Socket client = socket.EndAccept(asyncResult);   //结束应答
        //        StartReceive(client);
        //        StartAccept();
        //    }

        //    static void StartReceive(Socket client)
        //    {
        //        client.BeginReceive(buffer,0, buffer.Length,SocketFlags.None, ReceiveCallback,client);
        //    }

        //    static void ReceiveCallback(IAsyncResult asyncResult)
        //    {
        //        Socket client = asyncResult.AsyncState as Socket;

        //        int Length = client.EndReceive(asyncResult);

        //        if (Length == 0)
        //        {
        //           return; 
        //        }

        //        string str = Encoding.UTF8.GetString(buffer, 0, Length);

        //        Debug.LogInfo(str);

        //        StartReceive(client);
        //    }
        //}
    }
}
