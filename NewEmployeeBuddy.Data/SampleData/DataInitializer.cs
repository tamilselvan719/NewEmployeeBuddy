using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.SampleData
{
    /// <summary>
    /// This static class provides initial seed data to tables when the database is getting setup
    /// </summary>
    public static class DataInitializer
    {
        /// <summary>
        /// Initial Data for the Employee table
        /// </summary>
        public static List<NewEmployee> EmployeeInitialData()
        {
            var model = new List<NewEmployee>()
            {
                new NewEmployee() {
                    Id = Guid.NewGuid(),
                    FirstName= "Sahil",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "sahil@devcafe.com",
                    MobileNumber= "9876543210",
                    PhoneNumber= "9876543200",
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
                    Id = Guid.NewGuid(),
                    FirstName= "Sourab",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "sourab@devcafe.com",
                    MobileNumber= "9876543211",
                    PhoneNumber= "9876543212",
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
                    Id = Guid.NewGuid(),
                    FirstName= "Ritish",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "ritish@devcafe.com",
                    MobileNumber= "9876543220",
                    PhoneNumber= "9876543223",
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
                    Id = Guid.NewGuid(),
                    FirstName= "Himanshu",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "himanshu@devcafe.com",
                    MobileNumber= "9876543230",
                    PhoneNumber= "9876543232",
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
                    Id = Guid.NewGuid(),
                    FirstName= "Sneha",
                    MiddleName="",
                    LastName= "Sharma",
                    Gender = "Male",
                    DateOfBirth = DateTime.Now,
                    EmailAddress = "sneha@devcafe.com",
                    MobileNumber= "9876543240",
                    PhoneNumber= "9876543242",
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
            return model;
        }
    }
}
