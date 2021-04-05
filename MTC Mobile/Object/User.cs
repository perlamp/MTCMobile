using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;

namespace MTC_Mobile.Object
{
    class User
    {
        private int id;
        private string username;
        private string password;
        private AccessLevel accessLevel;

        public User()
        {

        }

        public User(string username, string password, AccessLevel accessLevel)
        {
            Crypt crypt = new Crypt();

            this.username = username;
            this.password = crypt.Encrypt(password);
            this.accessLevel = accessLevel;
        }

        public User(int id, string username, string password, AccessLevel accessLevel, Boolean encrypt)
        {
            if (encrypt)
            {
                Crypt crypt = new Crypt();
                password = crypt.Encrypt(password);
            }

            this.id = id;
            this.username = username;
            this.password = password;
            this.accessLevel = accessLevel;
        }

        public int? getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getUsername()
        {
            return this.username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string password)
        {
            Crypt crypt = new Crypt();

            this.password = crypt.Encrypt(password);
        }

        public AccessLevel getAccessLevel()
        {
            return this.accessLevel;
        }

        public void setAccessLevel(AccessLevel accessLevel)
        {
            this.accessLevel = accessLevel;
        }

        public Boolean validatePassword(string text)
        {
            Crypt crypt = new Crypt();

            return crypt.Validate(text, this.password);
        }


    }
}
