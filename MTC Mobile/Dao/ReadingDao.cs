using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;
using MTC_Mobile.Object;
using System.Data.SQLite;

namespace MTC_Mobile.Dao
{
    class ReadingDao: GenericDao, IDao<Reading>
    {

        public Response Insert(Reading reading)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Update(Reading reading)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Delete(Reading reading)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Reading GetById(int id)
        {
            Reading reading = null;

            con.Open();
            String qry = "SELECT * FROM readings WHERE id = '" + id.ToString() + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            //com.Parameters.AddWithValue("id", id.ToString());

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                reading = buildReading(reader);
            }
            reader.Close();
            con.Close();

            return reading;
        }

        public List<Reading> GetList()
        {
            List<Reading> listReadings = new List<Reading>();

            con.Open();
            String qry = "SELECT * FROM readings";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listReadings.Add(buildReading(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listReadings;
        }

        public List<Reading> GetList(string field, string value)
        {
            List<Reading> listReadings = new List<Reading>();

            con.Open();
            String qry = "SELECT * FROM readings WHERE "+field+" = '"+value+"'";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            //com.Parameters.AddWithValue("field", field);
            //com.Parameters.AddWithValue("value", value);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listReadings.Add(buildReading(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listReadings;
        }

        public List<Reading> Search(IDictionary<string, string> parameters)
        {
            List<Reading> listReadings = new List<Reading>();

            return listReadings;
        }

        private Reading buildReading(SQLiteDataReader reader){
            int id = System.Convert.ToInt32(reader["id"].ToString());
            String name = reader["name"].ToString();

            Reading reading = new Reading(id, name);

            return reading;
        }
    }
}
