using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;
using MTC_Mobile.Object;
using System.Data.SQLite;

namespace MTC_Mobile.Dao
{
    class AccessLevelDao : GenericDao, IDao<AccessLevel>
    {

        public Response Insert(AccessLevel accessLvl)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Update(AccessLevel accessLvl)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Delete(AccessLevel accessLvl)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public AccessLevel GetById(int id)
        {
            AccessLevel accessLvl = null;

            con.Open();
            String qry = "SELECT * FROM access_levels WHERE id = '" + id.ToString() + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                accessLvl = buildAccessLevel(reader);
            }
            reader.Close();
            con.Close();

            return accessLvl;
        }

        public List<AccessLevel> GetList()
        {
            List<AccessLevel> listAccessLvl = new List<AccessLevel>();

            con.Open();
            String qry = "SELECT * FROM access_levels";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listAccessLvl.Add(buildAccessLevel(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listAccessLvl;
        }

        public List<AccessLevel> GetList(string field, string value)
        {
            List<AccessLevel> listAccessLvl = new List<AccessLevel>();

            con.Open();
            String qry = "SELECT * FROM access_levels WHERE " + field + " = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listAccessLvl.Add(buildAccessLevel(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listAccessLvl;
        }

        public List<AccessLevel> Search(IDictionary<string, string> parameters)
        {
            List<AccessLevel> listAccessLvl = new List<AccessLevel>();

            return listAccessLvl;
        }

        public List<AccessLevel> GetByModule(string value)
        {
            List<AccessLevel> listAccessLvl = new List<AccessLevel>();

            con.Open();
            String qry = "SELECT access_levels.* "
                    + "FROM access_levels "
                    + "JOIN module_access ON module_access.access_level_id = access_levels.id "
                    + "WHERE module_id = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listAccessLvl.Add(buildAccessLevel(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listAccessLvl;
        }

        public List<AccessLevel> GetByReading(string value)
        {
            List<AccessLevel> listTables = new List<AccessLevel>();

            con.Open();
            String qry = "SELECT access_levels.* "
                    + "FROM access_levels "
                    + "JOIN reading_access ON reading_access.access_level_id = access_levels.id "
                    + "WHERE reading_id = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTables.Add(buildAccessLevel(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listTables;
        }

        private AccessLevel buildAccessLevel(SQLiteDataReader reader)
        {
            int id = System.Convert.ToInt32(reader["id"].ToString());
            String name = reader["name"].ToString();
            Boolean assignable = reader["id"].ToString().Equals("1");

            AccessLevel accessLvl = new AccessLevel(id, name, assignable);

            return accessLvl;
        }
    }
}
