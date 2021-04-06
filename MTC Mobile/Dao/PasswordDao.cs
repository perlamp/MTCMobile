using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Object;
using System.Data.SQLite;
using MTC_Mobile.Util;

namespace MTC_Mobile.Dao
{
    class PasswordDao : GenericDao, IDao<Password>
    {

        #region IDao<Password> Members

        public Response Insert(Password entity)
        {
            throw new NotImplementedException();
        }

        public Response Update(Password entity)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Password entity)
        {
            throw new NotImplementedException();
        }

        public Password GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Password> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Password> GetList(string field, string value)
        {
            throw new NotImplementedException();
        }

        public List<Password> Search(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDao<Password> Members

        Response IDao<Password>.Insert(Password entity)
        {
            throw new NotImplementedException();
        }

        Response IDao<Password>.Update(Password entity)
        {
            throw new NotImplementedException();
        }

        Response IDao<Password>.Delete(Password entity)
        {
            throw new NotImplementedException();
        }

        Password IDao<Password>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Password> IDao<Password>.GetList()
        {
            throw new NotImplementedException();
        }

        List<Password> IDao<Password>.GetList(string field, string value)
        {
            throw new NotImplementedException();
        }

        List<Password> IDao<Password>.Search(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
