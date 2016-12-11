using NewEmployeeBuddy.Data.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewEmployeeBuddy.Data.DataContext
{
    /// <summary>
    /// This class is used to seed the initial data into the database
    /// </summary>
    public class NewEmployeeDatabaseInitializer:
        //CreateDatabaseIfNotExists<NewEmployeeDbContext>
        DropCreateDatabaseIfModelChanges<NewEmployeeDbContext>
    {
        #region Seed Method
        /// <summary>
        /// This method is used to seed data into the tables
        /// </summary>
        /// <param name="context">Database Context of the project</param>
        protected override void Seed(NewEmployeeDbContext context)
        {
            context.Address.Add(AddressInitialData());
            context.Contact.Add(ContactInitialData());
            context.Payroll.Add(PayrollInitialData());
            context.Employee.Add(EmployeeInitialData());
            base.Seed(context);
        }
        #endregion

        #region Initial Data
        /// <summary>
        /// Initial Data for the Address table
        /// </summary>
        public Address AddressInitialData()
        {
            return new Address()
            {
                AddressId = new Guid(),
                House = "66",
                Ward = "12",
                Street = "Baker Street",
                Landmark = "Subway Station",
                City = "London",
                State = "London",
                Country = "UK",
                PinCode = "12121",
                AreaCode = "Ae345",
                EmployeeId = Guid.Parse("21EC2020-3AEA-4069-A2DD-08002B30309D"),
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                UpdatedBy = "User",
                UpdatedOn = DateTime.MinValue
            };
        }

        /// <summary>
        /// Initial Data for the Contact table
        /// </summary>
        public Contact ContactInitialData()
        {
            return new Contact()
            {
                ContactId = Guid.NewGuid(),
                Mobile = "9876543210",
                Landline = "012-999987",
                Fax = "1234567890",
                EmailAddress = "test@neb.com",
                EmployeeId = Guid.Parse("21EC2020-3AEA-4069-A2DD-08002B30309D"),
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                UpdatedBy = "User",
                UpdatedOn = DateTime.MinValue
            };
        }

        /// <summary>
        /// Initial Data for the Payroll table
        /// </summary>
        public Payroll PayrollInitialData()
        {
            return new Payroll()
            {
                PayrollId = Guid.NewGuid(),
                BasicPay = 20000.00M,
                FlexiblePay = 40000.00M,
                PFContribution = 5000.00M,
                Allowances = 15000.00M,
                TotalPay = 80000.00M,
                EmployeeId = Guid.Parse("21EC2020-3AEA-4069-A2DD-08002B30309D"),
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                UpdatedBy = "User",
                UpdatedOn = DateTime.MinValue
            };
        }

        /// <summary>
        /// Initial Data for the Employee table
        /// </summary>
        public Employee  EmployeeInitialData()
        {
            return new Employee()
            {
                EmployeeId = Guid.Parse("21EC2020-3AEA-4069-A2DD-08002B30309D"),
                FirstName = "Sahil",
                MiddleName = "",
                LastName = "Sharma",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                AddressId = AddressInitialData().AddressId,
                ContactId = ContactInitialData().ContactId,
                PayrollId = PayrollInitialData().PayrollId,
                CreatedBy = "System",
                CreatedOn = DateTime.Now,
                UpdatedBy = "System",
                UpdatedOn = DateTime.Now,
                IsActive = true
            };
        }
        #endregion
    }
}
