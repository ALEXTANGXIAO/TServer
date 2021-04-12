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
        private static int port = 54809;
        static void Main(string[] args)
        {
            InitLibImp();
            Server server = new Server(port);
            Console.Read();
        }

        private static void InitLibImp()
        {
            Util.ResigterEncode();
            Debug.LogApp();
            Debug.Log("===========START SOCKET SERVER============");
            Debug.Log("===========    Port:"+port +"     ============");
            TJson.RegistImp(new JsonImp());
        }
    }
}
