using System;
using System.Linq;
using System.Data.SQLite;
using MTC_Mobile.Dao;
using System.IO;
using MTC_Mobile.Util;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile
{
    class SecurityHandler_DB : GenericDao
    {
        static BAL_ENCRYPTER cypher = new BAL_ENCRYPTER();
        static String path = Path.GetDirectoryName(Process.GetCurrentProcess().StartInfo.FileName);
        //static String path = Path.GetDirectoryName(this.GetType().Assembly.GetModules()[0].FullyQualifiedName);

        public List<String> SelectAccessLevel(int userId)
        {
            List<String> lsRoles = new List<String>();
            try
            {
                con.Open();
                String sql2 = "SELECT * FROM access_levels WHERE ID = " + userId + ";";
                SQLiteCommand command2 = new SQLiteCommand(sql2, con);
                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    //String[] strTemp = new String[3];
                    lsRoles.Add(reader2["ID"].ToString());
                    lsRoles.Add(cypher.EncryptDecrypt(reader2["NAME"].ToString()));
                    lsRoles.Add(cypher.EncryptDecrypt(reader2["DESCRIPTION"].ToString()));
                }
                reader2.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lsRoles;
        }

        public String[] getAccessLevelFromName(String strName)
        {
            String[] strTemp = new String[3];
            try
            {
                con.Open();
                String sql2 = "SELECT * FROM access_level WHERE NAME = '" + cypher.EncryptDecrypt(strName) + "'; ";
                SQLiteCommand command2 = new SQLiteCommand(sql2, con);
                SQLiteDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {

                    strTemp[0] = reader2["ID"].ToString();
                    strTemp[1] = cypher.EncryptDecrypt(reader2["NAME"].ToString());
                    strTemp[2] = cypher.EncryptDecrypt(reader2["DESCRIPTION"].ToString());

                }
                reader2.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return strTemp;
        }


        public bool AddUser(String strName, String strPassword, String strAccessLevel, String strEmail, String strStatus)
        {
            bool bolResult = false;
            try
            {
                String[] strAccess = null;

                if (strAccessLevel != null)
                {
                    strAccess = getAccessLevelFromName(strAccessLevel);
                }

                con.Open();
                // insertamos el usuario
                String sql1 = "";
                if (strAccessLevel != null)
                {
                    sql1 = "INSERT INTO users (username, password, access_level_id, EMAIL, USER_STATUS) values ('" + cypher.EncryptDecrypt(strName) + "','" + cypher.EncryptDecrypt(strPassword) + "'," + strAccess[0] + ", '" + cypher.EncryptDecrypt(strEmail) + "',1)";
                }

                SQLiteCommand command1 = new SQLiteCommand(sql1, con);
                command1.ExecuteNonQuery();
                command1.Dispose();

                /// Obtenemos las contraseñas por default
                String sql2 = "select * from default_passwords where level <= 6"; //  + strMain[0];
                SQLiteCommand command2 = new SQLiteCommand(sql2, con);
                SQLiteDataReader reader2 = command2.ExecuteReader();

                /// Obtenemos el id del usuario para insertar en las tabla de passwords
                string sql3 = "Select id from users where username = '" + cypher.EncryptDecrypt(strName) + "'";
                SQLiteCommand command3 = new SQLiteCommand(sql3, con);
                SQLiteDataReader reader3 = command3.ExecuteReader();
                string UserID = "";
                while (reader3.Read())
                {
                    UserID = reader3["id"].ToString();

                }

                while (reader2.Read())
                {
                    String[] strTemp = new String[4];
                    strTemp[0] = (reader2["ID"].ToString());
                    strTemp[1] = (reader2["LEVEL"].ToString());
                    strTemp[2] = (reader2["PASSWORD"].ToString());
                    strTemp[3] = (reader2["GROUP"].ToString());
                    //lsUsers.Add(strTemp);
                    string sql4 = "Insert into passwords(USER_ID, LEVEL, PASSWORD, PASSWORD_OLD, GROUP_ID) VALUES (" + UserID + "," + strTemp[1] + ",'" + strTemp[2] + "',null," + strTemp[3] + ")";
                    SQLiteCommand command4 = new SQLiteCommand(sql4, con);
                    command4.ExecuteNonQuery();
                    command4.Dispose();
                }
                reader2.Close();


                con.Close();
                bolResult = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bolResult;
        }

        public bool deleteData()
        {
            bool bolResult = false;
            try
            {
                con.Open();
                String sql7 = "DELETE FROM passwords";
                SQLiteCommand command7 = new SQLiteCommand(sql7, con);
                command7.ExecuteNonQuery();

                //Users
                String sql1 = "DELETE FROM users";
                SQLiteCommand command1 = new SQLiteCommand(sql1, con);
                command1.ExecuteNonQuery();

                //Roles
                String sql2 = "DELETE FROM access_level";
                SQLiteCommand command2 = new SQLiteCommand(sql2, con);
                command2.ExecuteNonQuery();

                //Default Meter Passwords
                String sql4 = "DELETE FROM default_passwords";
                SQLiteCommand command4 = new SQLiteCommand(sql4, con);
                command4.ExecuteNonQuery();

                con.Close();

                bolResult = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bolResult;
        }

        public bool UpdatePasswords(string idRol, string passwordNew, string passwordOld)
        {
            bool bResult = false; 
            if (File.Exists(path + "Config\\MTCm.db"))
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE passwords SET PASSWORD='" + cypher.EncryptDecrypt(passwordNew) + "',PASSWORD_OLD ='" + cypher.EncryptDecrypt(passwordOld) + "' WHERE LEVEL = " + idRol + ";";
                    SQLiteCommand command = new SQLiteCommand(sql, con);
                    command.ExecuteNonQuery();
                    bResult = true;
                    con.Close();
                }
                catch (SQLiteException ex)
                {
                    throw ex;
                }
            }

            return bResult;
        }

    }
}
