using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Object
{
    class AccessLevel
    {
        private int id;

        private string name;

        private Boolean assignable;

        private Boolean visible;

        public AccessLevel() { }

        public AccessLevel(int id, string name, Boolean assignable)
        {
            this.id = id;
            this.name = name;
            this.assignable = assignable;
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

        public Boolean isAssignable()
        {
            return this.assignable;
        }

        public void setAssignable(Boolean assignable)
        {
            this.assignable = assignable;
        }

        public Boolean isVisible()
        {
            return this.visible;
        }

        public void setVisible(Boolean visible)
        {
            this.visible = visible;
        }

    }
}
