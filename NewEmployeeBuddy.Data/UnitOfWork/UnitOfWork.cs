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
        private readonly NewEmployeeDbContext _dbContext;
        private IEmployeeRepository _employee = null;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            _dbContext = new NewEmployeeDbContext();

        }
        #endregion

        #region Repositories
        public IEmployeeRepository Employee {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_dbContext);
                }
                return _employee;
            }
        }
        #endregion

        #region Save 
        public void Save()
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
