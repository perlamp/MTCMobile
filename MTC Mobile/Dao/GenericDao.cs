using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;
using System.Data.SQLite;

namespace MTC_Mobile.Dao
{
    class GenericDao
    {
        protected SQLiteConnection con = null; 

        public GenericDao()
        {
            Connection con = new Connection();

            this.con = con.getConnection();
        }

        protected int getLastId(SQLiteConnection con, string tableName)
        {
            int id;
            String qry = "SELECT last_insert_rowid() FROM " + tableName;
            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            reader.Read();
            id = Int32.Parse(reader[0].ToString());
            reader.Close();

            return id;
        }
    }
}
