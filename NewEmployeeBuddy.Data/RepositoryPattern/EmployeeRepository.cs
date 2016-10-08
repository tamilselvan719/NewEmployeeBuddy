using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.RepositoryPattern
{
    //CRUD operations for New Employee table using Repository Pattern
    public class EmployeeRepository : IRepository<NewEmployee>
    {
        //Constructor Injection
        private NewEmployeeDbContext _dbContext;
        public EmployeeRepository(NewEmployeeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //Add a new record to the New Employee table
        public void Add(NewEmployee entity)
        {
            _dbContext.NewEmployeeDetails.Add(entity);
        }

        //Delete a record in the New Employee table
        public void Delete(NewEmployee entity)
        {
            _dbContext.NewEmployeeDetails.Remove(entity);
        }

        //Delete a record using Phone Number in the New Employee table
        public void DeleteById(int phoneNumber)
        {
            NewEmployee record = _dbContext.NewEmployeeDetails.Find(phoneNumber);
            _dbContext.NewEmployeeDetails.Remove(record);
        }

        //Get All Data from New Employee table
        public IQueryable<NewEmployee> GetAll()
        {
            return _dbContext.NewEmployeeDetails.ToList() as IQueryable<NewEmployee>;
        }

        //Get a single record using Phone Number from New Employee table
        public NewEmployee GetById(int phoneNumber)
        {
            return _dbContext.NewEmployeeDetails.Find(phoneNumber);
        }

        //Update a record into the New Employee table
        public void Update(NewEmployee entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        //Save the changes 
        public void Save()
        {
            _dbContext.SaveChanges();
        }


        //Disposable Pattern - It is followed to dispose open connections / unused objects
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
