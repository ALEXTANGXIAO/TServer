using System;
using System.Collections.Generic;
using System.Text;

namespace SocketServer
{
    public enum LogLevel
    {
        DEBUG,
        INFO,
        WARNING,
        ERROR
    }

    class Debug
    {
        static public void Log(string str)
        {
            string Message = String.Format("{0}|{1}|", LogLevel.DEBUG,DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + str;

            Console.WriteLine(Message);
        }

        static public void LogWarning(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Message = String.Format("{0}|{1}|", LogLevel.WARNING, DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + str;
            Console.WriteLine(Message);
        }

        static public void LogError(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Message = String.Format("{0}|{1}|", LogLevel.ERROR, DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + str;
            Console.WriteLine(Message);
        }

        static public void LogInfo(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string Message = String.Format("{0}|{1}|", LogLevel.INFO, DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + str;
            Console.WriteLine(Message);
        }

        static public void Log(object value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string Message = String.Format("{0}|{1}|", LogLevel.DEBUG, DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + value.ToString();
            Console.WriteLine(value);
        }

        static public void LogInfo(object value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string Message = String.Format("{0}|{1}|", LogLevel.INFO, DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + value.ToString();
            Console.WriteLine(value);
        }

        static public void LogError(object value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Message = String.Format("{0}|{1}|", LogLevel.ERROR, DateTime.Now.ToString("yy-MM-dd hh:mm:ss")) + value.ToString();
            Console.WriteLine(value);
        }
    }
}
