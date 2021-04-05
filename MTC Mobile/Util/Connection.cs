using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace MTC_Mobile.Util
{
    class Connection
    {

        private SQLiteConnection con;

        public Connection()
        {
            string appPath = Path.GetDirectoryName(this.GetType().Assembly.GetModules()[0].FullyQualifiedName);
            string dbPath = Path.Combine(appPath, "Config\\MTCm.db");
            this.con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        }

        public SQLiteConnection getConnection()
        {
            return this.con;
        }

        public void setConnection(SQLiteConnection con)
        {
            this.con = con;
        }
    }
}
