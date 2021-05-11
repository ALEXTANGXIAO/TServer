using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerApp
{

    class SQL
    {

        ~SQL()
        {
            CloseMySql();
        }

        private const string m_source = "1.14.132.143";//106.52.118.65
        private const string m_userId = "root"; //tx
        private const string m_password = "123456";
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
                Debug.LogError("连接数据库失败");
                Debug.LogError(e);
                return;
            }
            Debug.LogWarning("连接数据库成功");
        }

        public void CloseMySql()
        {
            mySqlConn.Close();
        }
    }
}
