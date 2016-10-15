using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.RepositoryPattern
{
    /// <summary>
    /// A generic repository interface which takes a Model as class and operates accordingly.
    /// </summary>
    /// <typeparam name="T">T is any entity or data model class</typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteById(string id);
        void Save();
    }
}
