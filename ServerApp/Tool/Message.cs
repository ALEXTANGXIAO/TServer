using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketGameProtocol;
using Google.Protobuf;

namespace ServerApp
{
    class Message
    {
        /// <summary>
        /// 每条消息包头的长度
        /// </summary>
        private const int bufferHead = 4;   

        private static byte[] buffer = new byte[1024];

        private int startindex;

        public byte[] Buffer
        {
            get { return buffer; }
        }

        public int StartIndex
        {
            get { return startindex; }
        }

        /// <summary>
        /// Buffer剩余空间
        /// </summary>
        public int Remsize
        {
            get { return buffer.Length - startindex; }
        }

        public void ReadBuffer(int length,Action<MainPack> HandleRequest = null)
        {
            startindex += length;

            while (true)
            {

                if (startindex <= bufferHead)
                {
                    return;
                }

                int count = BitConverter.ToInt32(buffer, 0);

                int bufferAllCount = count + bufferHead;    //整条消息的长度

                if (startindex >= (count + bufferHead))
                {
                    MainPack pack = (MainPack)MainPack.Descriptor.Parser.ParseFrom(buffer, bufferHead,count);

                    if (HandleRequest != null)
                    {
                        HandleRequest(pack);
                    }

                    Array.Copy(buffer, bufferAllCount, buffer, 0,startindex - bufferAllCount);

                    startindex -= bufferAllCount;
                }
                else
                {
                    break;
                }
            }
        }

        public static byte[] PackData(MainPack pack)
        {
            byte[] data = pack.ToByteArray();//包体
            byte[] head = BitConverter.GetBytes(data.Length);//包头
            return head.Concat(data).ToArray();
        }

        public static Byte[] PackDataUDP(MainPack pack)
        {
            return pack.ToByteArray();
        }
    }
}
