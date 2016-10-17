namespace NewEmployeeBuddy.Data.Migrations
{
    using SampleData;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewEmployeeBuddy.Data.NewEmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// This method is used to seed data into the tables
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(NewEmployeeBuddy.Data.NewEmployeeDbContext context)
        {
            // Add initial data to Employee table
            //foreach (var data in DataInitializer.EmployeeInitialData())
            //{
            //    context.NewEmployeeDetails.AddOrUpdate(data);
            //}
        }
    }
}
