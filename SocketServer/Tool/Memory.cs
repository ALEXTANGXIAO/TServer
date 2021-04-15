using System;
using System.Collections.Generic;
using System.Text;

namespace SocketServer
{
    class Memory
    {
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
