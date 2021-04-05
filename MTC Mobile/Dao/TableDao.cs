using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Object;
using MTC_Mobile.Util;
using System.Data.SQLite;

namespace MTC_Mobile.Dao
{
    class TableDao: GenericDao, IDao<Table>
    {

        public Response Insert(Table table)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Update(Table table)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Response Delete(Table table)
        {
            Response response = new Response();
            response.setMessage("No soportado");

            return response;
        }

        public Table GetById(int id)
        {
            Table table = null;

            con.Open();
            String qry = "SELECT * FROM tables WHERE id = '" + id.ToString() + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            //com.Parameters.AddWithValue("id", id.ToString());

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                table = buildTable(reader);
            }
            reader.Close();
            con.Close();

            return table;
        }

        public List<Table> GetList()
        {
            List<Table> listTables = new List<Table>();

            con.Open();
            String qry = "SELECT * FROM tables";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTables.Add(buildTable(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listTables;
        }

        public List<Table> GetList(string field, string value)
        {
            List<Table> listTables = new List<Table>();

            con.Open();
            String qry = "SELECT * FROM tables WHERE " + field + " = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            //com.Parameters.AddWithValue("field", field);
            //com.Parameters.AddWithValue("value", value);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTables.Add(buildTable(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listTables;
        }

        public List<Table> Search(IDictionary<string, string> parameters)
        {
            List<Table> listTables = new List<Table>();

            return listTables;
        }

        public List<Table> GetByReading(string value)
        {
            List<Table> listTables = new List<Table>();

            con.Open();
            String qry = "SELECT tables.* "
                    + "FROM reading_tables "
                    + "JOIN tables ON tables.id = reading_tables.table_id "
                    + "WHERE reading_id = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            //com.Parameters.AddWithValue("field", field);
            //com.Parameters.AddWithValue("value", value);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listTables.Add(buildTable(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listTables;
        }

        private Table buildTable(SQLiteDataReader reader)
        {
            int id = System.Convert.ToInt32(reader["id"].ToString());
            String code = reader["code"].ToString();
            int? decade = (reader["decade"].ToString() != "" ?
                    (int?)System.Convert.ToInt32(reader["decade"].ToString()) : null);
            String name = reader["name"].ToString();
            int? minSize = (reader["max_size"].ToString() != "" ?
                    (int?)System.Convert.ToInt32(reader["min_size"].ToString()) : null);
            int? maxSize = (reader["max_size"].ToString() != "" ?
                    (int?)System.Convert.ToInt32(reader["max_size"].ToString()) : null);
            String constraints = (reader["constraints"].ToString() != "" ?
                    reader["constraints"].ToString() : null);

            Table table = new Table(id, code, decade, name, minSize, maxSize, constraints);

            return table;
        }
    }
}
