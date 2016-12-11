using System;

namespace NewEmployeeBuddy.Entities.DataTransferObjects.Employee
{
    public class EmployeeContactDTO
    {
        public Guid ContactId { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
    }
}
