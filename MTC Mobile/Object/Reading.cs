using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Dao;

namespace MTC_Mobile.Object
{
    class Reading
    {
        private int id;

        private string name;

        private List<Table> tables = null;

        private List<AccessLevel> accessLevels = null;

        public Reading(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public List<Table> getTables()
        {
            if (this.tables == null)
            {
                TableDao tableDao = new TableDao();
                this.tables = tableDao.GetByReading(this.id.ToString());
            }

            return this.tables;
        }

        public void setTables(List<Table> tables)
        {
            this.tables = tables;
        }

        public void addTable(Table table)
        {
            this.tables.Add(table);
        }

        public void removeTable(Table table)
        {
            this.tables.Remove(table);
        }

        public List<AccessLevel> getAccessLevels()
        {
            if (this.tables == null)
            {
                AccessLevelDao accessLevelDao = new AccessLevelDao();
                this.accessLevels = accessLevelDao.GetByReading(this.id.ToString());
            }

            return this.accessLevels;
        }

        public void setAccessLevels(List<AccessLevel> accessLevels)
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
