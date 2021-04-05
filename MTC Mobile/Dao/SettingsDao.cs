using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;
using System.Data.SQLite;

namespace MTC_Mobile.Dao
{
    class SettingsDao : GenericDao, IDao<Settings>
    {

        public Response Insert(Settings settings)
        {
            Response response = new Response();

            try
            {
                con.Open();

                String qry = "INSERT INTO settings (storage_path)"
                        + " VALUES ('" + settings.getStoragePath() + "')";
                SQLiteCommand com = new SQLiteCommand(qry, con);
                com.ExecuteNonQuery();
                int id = this.getLastId(con, "settings");
                
                con.Close();

                response.setResult(true);
                response.setInfo(id.ToString());
            }
            catch (Exception ex)
            {
                response.setMessage("No se pudo guardar el Usuario");
                response.setError(ex);
            };

            return response;
        }

        public Response Update(Settings settings)
        {
            Response response = new Response();

            try
            {
                con.Open();
                String qry = "UPDATE settings"
                        + " SET storage_path = '" + settings.getStoragePath() + "',"
                        + " user_id = '" + settings.getUserId() + "'"
                        + " WHERE id = '" + settings.getId() + "'";

                SQLiteCommand com = new SQLiteCommand(qry, con);
                com.ExecuteNonQuery();

                con.Close();

                response.setResult(true);

            }
            catch (Exception ex)
            {
                response.setMessage("No se pudo actualizar la Configuración");
                response.setError(ex);
            }

            return response;
        }

        public Response Delete(Settings settings)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Settings GetById(int id)
        {
            Settings settings = null;

            con.Open();
            String qry = "SELECT * FROM settings WHERE id = '" + id.ToString() + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                settings = buildSettings(reader);
            }
            reader.Close();
            con.Close();

            return settings;
        }

        public List<Settings> GetList()
        {
            List<Settings> listSettings = new List<Settings>();

            con.Open();
            String qry = "SELECT * FROM settings";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listSettings.Add(buildSettings(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listSettings;
        }

        public List<Settings> GetList(string field, string value)
        {
            List<Settings> listSettings = new List<Settings>();

            con.Open();
            String qry = "SELECT * FROM settings WHERE " + field + " = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listSettings.Add(buildSettings(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listSettings;
        }

        public List<Settings> Search(IDictionary<string, string> parameters)
        {
            List<Settings> listSettings = new List<Settings>();

            return listSettings;
        }

        private Settings buildSettings(SQLiteDataReader reader)
        {
            int id = System.Convert.ToInt32(reader["id"].ToString());
            string storagePath = reader["storage_path"].ToString();
            int? userId = (reader["user_id"].ToString() != "" ?
                (int?) System.Convert.ToInt32(reader["user_id"].ToString()) : null);

            Settings settings = new Settings(id, storagePath, userId);

            return settings;
        }
    }
}
