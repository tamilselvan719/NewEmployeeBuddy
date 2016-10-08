using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.SampleData
{
    public class DataInitializer
    {
        void SeedData()
        {
            var model = new List<NewEmployee>()
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
        }
    }
}
