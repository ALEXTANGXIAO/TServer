using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SocketGameProtocol;

namespace SocketServer.DAO
{
    class UserData
    {
        private MySqlConnection mySqlConn;
        //106.52.118.65:3306
        private string connstr = "database=tgame;data source=106.52.118.65;User Id=tx;password=txtx54tx;pooling=false;charset=utf8;port=3306";

        public UserData()
        {
            
        }

        private void ConnectMySql()
        {
            try
            {
                mySqlConn = new MySqlConnection(connstr);

                mySqlConn.Open();
            }
            catch(Exception e)
            {
                Debug.LogError("连接数据库失败");
                Debug.LogError(e);
            }
        }

        public bool Resigter(MainPack pack)
        {
            string username = pack.LoginPack.Username;
            string password = pack.LoginPack.Password;

            string sql = "SELECT * FROM tgame.user WHERE username = '@username'";
            MySqlCommand command = new MySqlCommand(sql, mySqlConn);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //用户名已经被注册
                Debug.LogError("用户名已经被注册");
                return false;
            }

            sql = "INSERT INTO 'tgame'.'user'('username','password') VALUES ('@username','@password')";
            command = new MySqlCommand(sql, mySqlConn);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }

            return true;
        }

        public bool Login(MainPack pack)
        {

            return true;
        }
    }
}

/*
 * 插入
 * INSERT INTO 'tb'.'user'('uname','upassword') VALUES ('admin','admin');
 *
 * 查询
 * SELECT * FROM tb.user WHERE uname = 'admin'
 *
 * 更新值
 * UPDATE 'mlzzf'.'register' SET 'time' = '2021-3-18 17:39:30','isreg' = '1' WHERE ('userid' = '11111111');
 *
 * 删除
 * DELETE FROM 'mlzzf'.'register' WHERE ('userid'='15701190220');
 *
 */
