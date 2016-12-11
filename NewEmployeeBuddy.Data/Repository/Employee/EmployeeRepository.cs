using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEmployeeBuddy.Data.Entities.Employee;
using NewEmployeeBuddy.Data.Repository.Base;
using System.Data.Entity;

namespace NewEmployeeBuddy.Data.Repository
{
    /// <summary>
    /// CRUD operations for Employee table using Generic Repository Pattern
    /// </summary>
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        #region Properties
        private readonly NewEmployeeDbContext _dbContext;
        #endregion

        #region Constructor
        public EmployeeRepository() : base(new NewEmployeeDbContext())
        {
            _dbContext = new NewEmployeeDbContext();
        }

        public EmployeeRepository(NewEmployeeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// To add a new record in Employee table
        /// </summary>
        /// <param name="employee">Instance of Employee class</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool AddEmployeeDetails(Employee employee)
        {
            try
            {
                if (employee == null)
                    return false;

                _dbContext.Employee.Add(employee);
                return true;
                //Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To delete a record from the Employee table
        /// </summary>
        /// <param name="employee">The instance of Employee class</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool DeleteEmployeeDetails(Employee employee)
        {
            try
            {
                if (employee == null)
                    return false;

                var deleteEmployee = _dbContext.Employee.FirstOrDefault(emp => emp.EmployeeId == employee.EmployeeId);
                _dbContext.Employee.Remove(deleteEmployee);
                return true;
                //Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To delete a record using Employee ID of the Employee table
        /// </summary>
        /// <param name="employeeID">Primary Key of the row (Employee ID)</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool DeleteEmployeeDetailsByID(Guid employeeId)
        {
            try
            {
                if (Guid.Equals(employeeId, Guid.Empty))
                    return false;

                Employee record = _dbContext.Employee.Find(employeeId);
                _dbContext.Employee.Remove(record);
                return true;
                //Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get a single record using Address ID from Address table
        /// </summary>
        /// <param name="addressID">Primary Key of the row (Address ID)</param>
        /// <returns>Returns a Address row matching the passing ID</returns>
        public Address GetAddressDetails(Guid addressId)
        {
            try
            {
                if (Guid.Equals(addressId, Guid.Empty))
                    return new Address();

                return _dbContext.Address.Find(addressId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get all data from Employee table
        /// </summary>
        /// <returns>An IQuerable List of Employee</returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _dbContext.Employee.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get a single record using Contact ID from Contact table
        /// </summary>
        /// <param name="contactID">Primary Key of the row (Contact ID)</param>
        /// <returns>Returns a Contact row matching the passing ID</returns>
        public Contact GetContactDetails(Guid contactId)
        {
            try
            {
                if (Guid.Equals(contactId, Guid.Empty))
                    return new Contact();

                return _dbContext.Contact.Find(contactId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get a single record using Employee ID from Employee table
        /// </summary>
        /// <param name="employeeID">Primary Key of the row (Employee ID)</param>
        /// <returns>Returns a Employee row matching the passing ID</returns>
        public Employee GetEmployeeDetailsByID(Guid employeeId)
        {
            try
            {
                if (Guid.Equals(employeeId, Guid.Empty))
                    return new Employee();

                    return _dbContext.Employee.Find(employeeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get a single record using Payroll ID from Payroll table
        /// </summary>
        /// <param name="payrollID">Primary Key of the row (Payroll ID)</param>
        /// <returns>Returns a Payroll row matching the passing ID</returns>
        public Payroll GetPayrollDetails(Guid payrollId)
        {
            try
            {
                if (Guid.Equals(payrollId, Guid.Empty))
                    return new Payroll();

                return _dbContext.Payroll.Find(payrollId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To update a record in Employee table
        /// </summary>
        /// <param name="employee">The instance of Employee class</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool UpdateEmployeeDetails(Employee employee)
        {
            try
            {
                if (employee == null)
                    return false;

                _dbContext.Entry(employee).State = EntityState.Modified;
                return true;
                //Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
