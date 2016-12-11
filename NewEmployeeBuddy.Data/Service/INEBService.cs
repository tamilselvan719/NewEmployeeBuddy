using NewEmployeeBuddy.Entities.DataTransferObjects.Employee;
using System;
using System.Collections.Generic;

namespace NewEmployeeBuddy.Data.Service
{
    public interface INEBService
    {
        //Employee CRUD Operations
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeByID(Guid employeeID);
        bool AddEmployee(EmployeeDTO employee);
        bool DeleteEmployeeByID(Guid employeeID);
        bool DeleteEmployee(EmployeeDTO employee);
        bool UpdateEmployee(EmployeeDTO employee);
    }
}
