using NewEmployeeBuddy.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEmployeeBuddy.Data.Entities.Employee
{
    [Table("tbl_Payroll")]
    public class Payroll: BaseEntity
    {
        [Key, ForeignKey("Employee")]
        public Guid PayrollId { get; set; }
        public decimal BasicPay { get; set; }
        public decimal FlexiblePay { get; set; }
        public decimal PFContribution { get; set; }
        public decimal Allowances { get; set; }
        public decimal TotalPay { get; set; }
        public Guid EmployeeId { get; set; }

        //Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
