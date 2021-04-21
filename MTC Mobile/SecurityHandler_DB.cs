using System;
using System.Linq;
using System.Data.SQLite;
using MTC_Mobile.Dao;
using MTC_Mobile.Util;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile
{
    class SecurityHandler_DB : GenericDao
    {
        static BAL_ENCRYPTER cypher = new BAL_ENCRYPTER();

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

    }
}
