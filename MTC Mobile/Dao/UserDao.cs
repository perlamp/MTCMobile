using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Object;
using System.Data.SQLite;
using MTC_Mobile.Util;

namespace MTC_Mobile.Dao
{
    class UserDao: GenericDao, IDao<User>
    {

        public Response Insert(User user)
        {
            Response response = new Response();

            try
            {
                con.Open();
                String qry = "INSERT INTO users (username, password, access_level_id)"
                        + " VALUES ('" + user.getUsername() + "',"
                        + " '" + user.getPassword() + "', "
                        + user.getAccessLevel().getId().ToString() + ")";

                SQLiteCommand com = new SQLiteCommand(qry, con);
                com.ExecuteNonQuery();

                con.Close();

                response.setResult(true);

            }
            catch (Exception ex)
            {
                response.setMessage("No se pudo guardar el Usuario");
                response.setError(ex);
            }

            return response;
        }

        public Response Update(User user)
        {
            Response response = new Response();

            try
            {
                con.Open();
                String qry = "UPDATE users"
                        + " SET username = '" + user.getUsername() + "',"
                        + " password = '" + user.getPassword() + "',"
                        + " access_level_id = " + user.getAccessLevel().getId().ToString()
                        + " WHERE id = '" + user.getId() + "'";

                SQLiteCommand com = new SQLiteCommand(qry, con);
                com.ExecuteNonQuery();

                con.Close();

                response.setResult(true);

            }
            catch (Exception ex)
            {
                response.setMessage("No se pudo actualizar el Usuario");
                response.setError(ex);
            }

            return response;
        }

        public Response Delete(User user)
        {
            Response response = new Response();

            try
            {
                con.Open();
                String qry = "DELETE FROM users"
                        + " WHERE username = '" + user.getUsername() + "'";

                SQLiteCommand com = new SQLiteCommand(qry, con);
                com.ExecuteNonQuery();

                con.Close();

                response.setResult(true);

            }
            catch (Exception ex)
            {
                response.setMessage("No se pudo eliminar el Usuario");
                response.setError(ex);
            }

            return response;
        }

        public User GetById(int id)
        {
            User user = null;
            
            con.Open();
            String qry = "SELECT * FROM users WHERE id = '" + id.ToString() + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = buildUser(reader);
            }
            reader.Close();
            con.Close();

            return user;
        }

        public List<User> GetList()
        {
            List<User> listUsers = new List<User>();

            con.Open();
            String qry = "SELECT * FROM users";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listUsers.Add(buildUser(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listUsers;
        }

        public List<User> GetList(string field, string value)
        {
            List<User> listUsers = new List<User>();

            con.Open();
            String qry = "SELECT * FROM users WHERE " + field + " = '" + value + "'";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            //com.Parameters.AddWithValue("field", field);
            //com.Parameters.AddWithValue("value", value);

            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listUsers.Add(buildUser(reader));
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listUsers;
        }

        public List<User> Search(IDictionary<string, string> parameters)
        {
            List<User> listUsers = new List<User>();

            String username = parameters["username"];
            String accessLvlId = parameters["accessLvlId"];

            con.Open();
            String qry = "SELECT * FROM users WHERE username LIKE '%" + username + "%'";

            if (!accessLvlId.Equals(""))
            {
                qry += " AND access_level_id = '" + accessLvlId + "'";
            }

            qry += " ORDER BY username";

            SQLiteCommand com = new SQLiteCommand(qry, con);
            SQLiteDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = buildUser(reader);
                    if (user.getAccessLevel().isAssignable())
                    {
                        listUsers.Add(buildUser(reader));
                    }
                    
                }

                reader.NextResult();
            }
            reader.Close();
            con.Close();

            return listUsers;
        }

        private User buildUser(SQLiteDataReader reader)
        {
            int id = System.Convert.ToInt32(reader["id"].ToString());
            String username = reader["username"].ToString();
            String password = reader["password"].ToString();
            int accessLvlId = System.Convert.ToInt32(reader["access_level_id"].ToString());

            IDao<AccessLevel> accessLvlDao = new AccessLevelDao();
            AccessLevel accessLvl = accessLvlDao.GetById(accessLvlId);

            User user = new User(id, username, password, accessLvl, false);

            return user;
        }
    }
}
