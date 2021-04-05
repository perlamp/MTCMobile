using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Object;
using MTC_Mobile.Dao;

namespace MTC_Mobile.Util
{
    class Auth
    {

        public Response logIn(String username, String password)
        {
            Boolean result = false;
            String message = "";

            IDao<User> dao = new UserDao();
            List<User> listUser = dao.GetList("username", username);
            User user = (listUser.Count > 0 ? listUser[0] : null);
            
            if (user != null)
            {
                if (user.validatePassword(password))
                {
                    IDao<Settings> settingsDao = new SettingsDao();
                    Settings settings = settingsDao.GetById(1);
                    settings.setUserId(user.getId());
                    settingsDao.Update(settings);

                    result = true;
                }
                else
                {
                    message = "La contraseña no coincide";
                }
            }
            else
            {
                message = "No se encuentra el usuario";
            }

            return new Response(result, message); ;
        }
    }
}
