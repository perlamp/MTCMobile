using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Object
{
    class DefaultPassword
    {
        private int id;
        private int level;
        private String password;
        private int group;

        public DefaultPassword()
        {

        }

        public DefaultPassword(int id, int level, string password, int group)
        {
            this.id = id;
            this.level = level;
            this.password=password;
            this.group = group;
        }

    }
}
