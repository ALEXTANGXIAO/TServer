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
            string Message = String.Format("{0}|{1}|", LogLevel.DEBUG,DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + str;

            Console.WriteLine(Message);
        }

        static public void LogWarning(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Message = String.Format("{0}|{1}|", LogLevel.WARNING, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + str;
            Console.WriteLine(Message);
        }

        static public void LogError(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Message = String.Format("{0}|{1}|", LogLevel.ERROR, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + str;
            Console.WriteLine(Message);
        }

        static public void LogInfo(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string Message = String.Format("{0}|{1}|", LogLevel.INFO, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + str;
            Console.WriteLine(Message);
        }

        static public void Log(object value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string Message = String.Format("{0}|{1}|", LogLevel.DEBUG, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + value.ToString();
            Console.WriteLine(Message);
        }

        static public void LogInfo(object value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string Message = String.Format("{0}|{1}|", LogLevel.INFO, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + value.ToString();
            Console.WriteLine(Message);
        }

        static public void LogError(object value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string Message = String.Format("{0}|{1}|", LogLevel.ERROR, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) + value.ToString();
            Console.WriteLine(Message);
        }

        private static string s = "\r\n   ___ _                 _\r\n  / __\\ | ___  _   _  __| |_ __ _____   _____\r\n / /  | |/ _ \\| | | |/ _ | '__/ _ \\ \\ / / _ \\\r\n/ /___| | (_) | |_| | (_| | | |  __/\\ V /  __/\r\n\\____/|_|\\___/ \\__,_|\\__,_|_|  \\___| \\_/ \\___|\r\n\r\n   V1.0.0  Commit #TANG  Pro=true\r\n================================================\r\n\r\n[Info]    {0} 初始化数据库连接\r\n[Info]    {1} 数据库版本匹配，跳过数据库迁移\r\n[Info]    {2} 初始化任务队列，WorkerNum = 10\r\n[Info]    {3} 初始化定时任务...\r\n[Info]    {4} 当前运行模式：Master";

        static public void LogApp()
        {
            string Message = String.Format(s, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Debug.Log(Message);
        }
    }
}
