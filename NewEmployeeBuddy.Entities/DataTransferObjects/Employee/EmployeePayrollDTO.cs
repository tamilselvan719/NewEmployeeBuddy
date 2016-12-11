using System;

namespace NewEmployeeBuddy.Entities.DataTransferObjects.Employee
{
    public class EmployeePayrollDTO
    {
        public Guid PayrollId { get; set; }
        public decimal BasicPay { get; set; }
        public decimal FlexiblePay { get; set; }
        public decimal PFContribution { get; set; }
        public decimal Allowances { get; set; }
        public decimal TotalPay { get; set; }
    }
}
