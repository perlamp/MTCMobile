using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;
using MTC_Mobile.Object;
using System.Data.SQLite;

namespace MTC_Mobile.Dao
{
    class ModuleDao : GenericDao, IDao<Module>
    {

        public Response Insert(Module module)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Update(Module module)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Delete(Module module)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Module GetById(int id)
        {
            Module module = null;

            con.Open();
            String qry = "SELECT * FROM modules WHERE id = '" + id.ToString() + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                module = buildModule(reader);
            }
            reader.Close();
            con.Close();

            return module;
        }

        public List<Module> GetList()
        {
            List<Module> listModules = new List<Module>();

            con.Open();
            String qry = "SELECT * FROM modules";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listModules.Add(buildModule(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listModules;
        }

        public List<Module> GetList(string field, string value)
        {
            List<Module> listModules = new List<Module>();

            con.Open();
            String qry = "SELECT * FROM modules WHERE " + field + " = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listModules.Add(buildModule(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listModules;
        }

        public List<Module> Search(IDictionary<string, string> parameters)
        {
            List<Module> listModules = new List<Module>();

            return listModules;
        }

        public List<Module> GetByReading(string value)
        {
            List<Module> listModules = new List<Module>();

            con.Open();
            String qry = "SELECT modules.* "
                    + "FROM module_access "
                    + "JOIN modules ON modules.id = module_access.module_id "
                    + "WHERE access_level_id = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listModules.Add(buildModule(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listModules;
        }

        private Module buildModule(SQLiteDataReader reader)
        {
            int id = System.Convert.ToInt32(reader["id"].ToString());
            String name = reader["name"].ToString();

            Module module = new Module(id, name);

            return module;
        }
    }
}
