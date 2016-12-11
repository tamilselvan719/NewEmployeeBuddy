using System;
using System.Collections.Generic;
using NewEmployeeBuddy.Data.Entities.Employee;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEmployeeBuddy.Data.Repository.Base;

namespace NewEmployeeBuddy.Data.Repository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeDetailsByID(Guid employeeID);
        Address GetAddressDetails(Guid addressID);
        Contact GetContactDetails(Guid contactID);
        Payroll GetPayrollDetails(Guid payrollID);

        bool AddEmployeeDetails(Employee employee);

        bool DeleteEmployeeDetails(Employee employee);
        bool DeleteEmployeeDetailsByID(Guid employeeID);

        bool UpdateEmployeeDetails(Employee employee);
    }
}
