using System;

namespace NewEmployeeBuddy.Entities.DataTransferObjects.Employee
{
    public class EmployeeAddressDTO
    {
        public Guid AddressId { get; set; }
        public string House { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string AreaCode { get; set; }
        public string Landmark { get; set; }
    }
}
