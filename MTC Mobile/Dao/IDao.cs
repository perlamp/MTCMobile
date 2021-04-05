using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MTC_Mobile.Util;

namespace MTC_Mobile.Dao
{
    public interface IDao<T> where T: class
    {
        Response Insert(T entity);
        
        Response Update(T entity);
        
        Response Delete(T entity);

        T GetById(int id);

        List<T> GetList();

        List<T> GetList(string field, string value);

        List<T> Search(IDictionary<string, string> parameters);
    }
}
