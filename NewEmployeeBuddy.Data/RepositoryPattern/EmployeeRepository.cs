using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.RepositoryPattern
{
    /// <summary>
    /// CRUD operations for New Employee table using Repository Pattern
    /// </summary>
    public class EmployeeRepository : IRepository<NewEmployee>
    {
        /// <summary>
        /// Constructor Injection
        /// </summary>
        private NewEmployeeDbContext _dbContext;
        public EmployeeRepository(NewEmployeeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// To add a new record in New Employee table
        /// </summary>
        /// <param name="entity">Instance of New Employee</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool Add(NewEmployee entity)
        {
            var result = false;
            try
            {
                if (entity != null)
                {
                    _dbContext.NewEmployeeDetails.Add(entity);
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To delete a record from the New Employee table
        /// </summary>
        /// <param name="entity">Instance of New Employee</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool Delete(NewEmployee entity)
        {
            var result = false;
            try
            {
                if (entity != null)
                {
                    _dbContext.NewEmployeeDetails.Remove(entity);
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To delete a record using Phone Number in the New Employee table
        /// </summary>
        /// <param name="phoneNumber">Primary Key of the row (Phone Number)</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool DeleteById(string id)
        {
            var result = false;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    NewEmployee record = _dbContext.NewEmployeeDetails.Find(id);
                    _dbContext.NewEmployeeDetails.Remove(record);
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To get all data from New Employee table
        /// </summary>
        /// <returns>An IQuerable List of NewEmployee</returns>
        public IEnumerable<NewEmployee> GetAll()
        {
            var result = new List<NewEmployee>();
            try
            {
                result = _dbContext.NewEmployeeDetails.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To get a single record using Phone Number from New Employee table
        /// </summary>
        /// <param name="phoneNumber">Primary Key of the row (Phone Number)</param>
        /// <returns>Returns a NewEmployee row matching the passing ID</returns>
        public NewEmployee GetById(string id)
        {
            var result = new NewEmployee();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    result = _dbContext.NewEmployeeDetails.Find(id); ;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To update a record in New Employee table
        /// </summary>
        /// <param name="entity">Instance of New Employee</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool Update(NewEmployee entity)
        {
            var result = false;
            try
            {
                if (entity != null)
                {
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// Tp save the changes 
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposable Pattern - It is used to dispose open connections / unused reference type objects
        /// </summary>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
