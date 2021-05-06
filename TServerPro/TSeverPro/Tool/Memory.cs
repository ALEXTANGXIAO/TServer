using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp
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
