namespace NewEmployeeBuddy.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewEmployeeBuddy.Data.NewEmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewEmployeeBuddy.Data.NewEmployeeDbContext context)
        {
             var model =  new List<NewEmployee>()
            {
                new NewEmployee() {
                    JoinerID = Guid.NewGuid(),
                    FirstName= "Sahil",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "sahil@devcafe.com",
                    MobileNumber= "9876543210",
                    PhoneNumber= "9876543210",
                    Address = "563-Sector 31, Gurgaon",
                    City = "Gurgaon",
                    State="Haryana",
                    Country = "India",
                    PinCode= "9876543210",
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy= "System",
                    UpdatedOn=DateTime.Now,
                    IsActive = true
                },
                new NewEmployee() {
                    JoinerID = Guid.NewGuid(),
                    FirstName= "Sourab",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "sourab@devcafe.com",
                    MobileNumber= "9876543210",
                    PhoneNumber= "9876543210",
                    Address = "563-Sector 31, Gurgaon",
                    City = "Gurgaon",
                    State="Haryana",
                    Country = "India",
                    PinCode= "9876543210",
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy= "System",
                    UpdatedOn=DateTime.Now,
                    IsActive = true
                },
                new NewEmployee() {
                    JoinerID = Guid.NewGuid(),
                    FirstName= "Ritish",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "ritish@devcafe.com",
                    MobileNumber= "9876543210",
                    PhoneNumber= "9876543210",
                    Address = "563-Sector 31, Gurgaon",
                    City = "Gurgaon",
                    State="Haryana",
                    Country = "India",
                    PinCode= "9876543210",
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy= "System",
                    UpdatedOn=DateTime.Now,
                    IsActive = true
                },
                new NewEmployee() {
                    JoinerID = Guid.NewGuid(),
                    FirstName= "Himanshu",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "himanshu@devcafe.com",
                    MobileNumber= "9876543210",
                    PhoneNumber= "9876543210",
                    Address = "563-Sector 31, Gurgaon",
                    City = "Gurgaon",
                    State="Haryana",
                    Country = "India",
                    PinCode= "9876543210",
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy= "System",
                    UpdatedOn=DateTime.Now,
                    IsActive = true
                },
                new NewEmployee() {
                    JoinerID = Guid.NewGuid(),
                    FirstName= "Sneha",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "sneha@devcafe.com",
                    MobileNumber= "9876543210",
                    PhoneNumber= "9876543210",
                    Address = "563-Sector 31, Gurgaon",
                    City = "Gurgaon",
                    State="Haryana",
                    Country = "India",
                    PinCode= "9876543210",
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    UpdatedBy= "System",
                    UpdatedOn=DateTime.Now,
                    IsActive = true
                }
        };
            foreach (var item in model)
            {
                context.NewEmployeeDetails.AddOrUpdate(item);
            }
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
