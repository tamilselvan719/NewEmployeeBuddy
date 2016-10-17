using NewEmployeeBuddy.Data.SampleData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.DataContext
{
    /// <summary>
    /// Data Initializer class used to seed the initial data into the database
    /// </summary>
    public class DbContextInitializer: DropCreateDatabaseIfModelChanges<NewEmployeeDbContext>
    {
        /// <summary>
        /// This method is used to seed data into the tables
        /// </summary>
        /// <param name="context">Database Context of our project</param>
        protected override void Seed(NewEmployeeDbContext context)
        {
            // Add initial data to Employee table
            foreach (var data in DataInitializer.EmployeeInitialData())
            {
                context.NewEmployeeDetails.AddOrUpdate(data);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
