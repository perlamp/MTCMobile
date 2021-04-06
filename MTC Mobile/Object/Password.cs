using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Object
{
    class Password
    {
        private int id;
        private User user;
        private AccessLevel accessLevel;
        private String password;
        private String passwordOld;
        private int groupId;

        public Password()
        {

        }

        public Password(int id, User user, AccessLevel accessLevel, string password, String passwordOld, int groupId)
        {
            this.id = id;
            this.user = user;
            this.accessLevel = accessLevel;
            this.password=password;
            this.passwordOld=passwordOld;
            this.groupId = groupId;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public User getUser()
        {
            return this.user;
        }

        public void setUser(User user)
        {
            this.user = user;
        }

        public AccessLevel getAccessLevel()
        {
            return this.accessLevel;
        }

        public void setAccessLevel(AccessLevel accessLevel)
        {
            this.accessLevel = accessLevel;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getPasswordOld()
        {
            return this.passwordOld;
        }

        public void setPasswordOld(string passwordOld)
        {
            this.passwordOld = passwordOld;
        }

        public int getGroupId()
        {
            return this.groupId;
        }

        public void setGroupId(int groupId)
        {
            this.groupId = groupId;
        }

    }
}
