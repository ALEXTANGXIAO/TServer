using System;
using System.IO;
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
            InitLibImp();
            Server server = new Server(6666);
            Console.Read();
        }

        private static void InitLibImp()
        {
            Util.ResigterEncode();
            Debug.LogApp();
            Debug.Log("===========START SOCKET SERVER============");
            TJson.RegistImp(new JsonImp());
        }
    }
}
