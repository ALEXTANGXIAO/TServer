using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SocketGameProtocol;

namespace SocketServer.DAO
{
    class UserData
    {
        public bool Register(MainPack pack,MySqlConnection mySqlConnection)
        {
            string username = pack.LoginPack.Username;
            string password = pack.LoginPack.Password;

            string sql = "SELECT * FROM tgame.userlist WHERE username = ' " + username + "";
            MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
            //MySqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    //用户名已经被注册
            //    Debug.LogError("USER HAD RESIGTER");
            //    return false;
            //}
            //reader.Close();


            sql = "INSERT INTO tgame.userlist(username,password) VALUES ('" + username + "','" + password + "')";
            command = new MySqlCommand(sql, mySqlConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }
            Debug.LogInfo("注册用户成功:username:" + username + " password:" + password);
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
