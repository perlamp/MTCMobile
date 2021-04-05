using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Dao;

namespace MTC_Mobile.Object
{
    class Module
    {
        private int id;

        private string name;

        private List<AccessLevel> accessLevels = null;

        public Module() { }

        public Module(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public List<AccessLevel> getAccessLevels()
        {
            if (this.accessLevels == null)
            {
                AccessLevelDao accessLvlDao = new AccessLevelDao();
                this.accessLevels = accessLvlDao.GetByModule(this.id.ToString());
            }

            return this.accessLevels;
        }

        public void setAccesslevels(List<AccessLevel> accessLevels)
        {
            this.accessLevels = accessLevels;
        }

        public void addAccessLevel(AccessLevel accessLevel)
        {
            this.accessLevels.Add(accessLevel);
        }

        public void removeAccessLevel(AccessLevel accessLevel)
        {
            this.accessLevels.Remove(accessLevel);
        }
    }
}
