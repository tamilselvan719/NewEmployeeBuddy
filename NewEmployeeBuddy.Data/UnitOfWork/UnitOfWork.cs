using NewEmployeeBuddy.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Properties
        private bool _disposed = false;
        private NewEmployeeDbContext _dbContext;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            CreateDbContext();
        }
        #endregion

        #region Repositories
        public IEmployeeRepository Employee { get { return new EmployeeRepository(_dbContext); } }
        #endregion

        #region Methods
        protected void CreateDbContext()
        {
            _dbContext = new NewEmployeeDbContext();

            //Todo
            //_dbContext.Configuration.ProxyCreationEnabled = false;
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
        } 

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        #endregion

        #region IDisposable Implementation to dispose open connections/unused reference type objects
        public void Dispose()
        {
            Dispose(true);
            //Prevent the GC from calling Object.Finalize on an
            //object that does not require it
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion
    }
}
