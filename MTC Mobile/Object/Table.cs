using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MTC_Mobile.Object
{
    class Table
    {
        private int id;

        private string code;

        private int? decade;

        private string name;

        private int? minSize;

        private int? maxSize;

        private string constraints;

        public Table(int id, string code, int? decade, string name,
                int? minSize, int? maxSize, string constraints)
        {
            this.id = id;
            this.code = code;
            this.decade = decade;
            this.name = name;
            this.minSize = minSize;
            this.maxSize = maxSize;
            this.constraints = constraints;
        }

        public int getId()
        {
            return this.id;
        }

        public string getCode()
        {
            return this.code;
        }

        public int? getDecade()
        {
            return this.decade;
        }

        public string getName()
        {
            return this.name;
        }

        public int? getMinSize()
        {
            return this.minSize;
        }

        public int? getMaxSize()
        {
            return this.maxSize;
        }

        public string getConstraints()
        {
            return this.constraints;
        }
    }
}
