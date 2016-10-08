using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data
{
    public class NewEmployeeDbContext : DbContext
    {
        public NewEmployeeDbContext() : base(nameOrConnectionString: "SqlConnect") { }
        public DbSet<NewEmployee> NewEmployeeDetails { get; set; }
    }
}
