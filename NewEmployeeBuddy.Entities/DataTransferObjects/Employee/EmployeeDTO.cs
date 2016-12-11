using System;
using System.ComponentModel.DataAnnotations;

namespace NewEmployeeBuddy.Entities.DataTransferObjects.Employee
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        //Payroll Details
        public EmployeePayrollDTO Payroll { get; set; }

        //Contact Details
        public EmployeeContactDTO Contact { get; set; }

        //Address Details
        public EmployeeAddressDTO Address { get; set; }
    }
}
