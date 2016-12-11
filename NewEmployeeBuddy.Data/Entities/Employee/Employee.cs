using NewEmployeeBuddy.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace NewEmployeeBuddy.Data.Entities.Employee
{
    [Table("tbl_Employee")]
    public class Employee: BaseEntity
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [MaxLength]
        public string FirstName { get; set; }
        [MaxLength]
        public string MiddleName { get; set; }
        [MaxLength]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        public Guid AddressId { get; set; }
        public Guid ContactId { get; set; }
        public Guid PayrollId { get; set; }


        //Navigation Properties
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Payroll Payroll { get; set; }
    }
}
