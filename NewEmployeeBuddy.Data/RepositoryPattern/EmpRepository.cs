using NewEmployeeBuddy.Data.RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NewEmployeeBuddy.Data.RepositoryPattern
{
    public class EmpRepository : RepositoryBase<NewEmployee>
    {
        public EmpRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
