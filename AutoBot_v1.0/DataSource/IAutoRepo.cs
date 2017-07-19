using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public interface IAutoRepo<T> where T : class
    {
        List<T> All();
        List<T> FindAll(Func<T, bool> exp);
        List<T> Where(Func<T, bool> exp);
        T Single(Func<T, bool> exp);
        T First(Func<T, bool> exp);
        T Last(Func<T, bool> exp);
        T Save(T entity);
        T Insert(T entity);
        void Destroy(T entity);
        void Delete(T entity);
        void UnDelete(T entity);
        void MarkForDeletion(T entity);
        T CreateInstance();
        /// <summary>Persist the data context.</summary>
        void SaveAll();
    }
}
