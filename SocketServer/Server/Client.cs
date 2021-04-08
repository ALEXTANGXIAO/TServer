using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using SocketGameProtocol;
using SocketServer.DAO;

namespace SocketServer
{
    class Client
    {
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

            this.server = server;
            this.socket = socket;

            StartReceive();
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
                throw;
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
    }
}
