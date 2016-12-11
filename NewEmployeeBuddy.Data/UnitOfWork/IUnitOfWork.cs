using NewEmployeeBuddy.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
