using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data
{
    /// <summary>
    /// This class is the starting entry of our project with Entity Framework; 
    /// here we define connection string, add tables and other configurations
    /// </summary>
    public class NewEmployeeDbContext : DbContext
    {
        public NewEmployeeDbContext() : base("NewEmployeeBuddy") { }

        //Add models here to reflect as tables in database
        public DbSet<NewEmployee> NewEmployeeDetails { get; set; }

        /// <summary>
        /// This method is used to define custom settings on Models defined above
        /// A common scenario is if in Model-First approach , suppose the tables are already created in database
        /// and you want to map your models with it, simply use "To Table" (shown in Line-32)
        /// Another scenario is by default, Entity Framework pluralize tables. 
        /// To stop it from doing that remove the convention 'PluralizingEntitySetNameConvention' (shown in Line-33)
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewEmployee>().ToTable("Employee");
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
