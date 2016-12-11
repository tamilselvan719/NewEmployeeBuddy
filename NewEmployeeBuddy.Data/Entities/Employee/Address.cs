using NewEmployeeBuddy.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEmployeeBuddy.Data.Entities.Employee
{
    [Table("tbl_Address")]
    public class Address: BaseEntity
    {
        [Key, ForeignKey("Employee")]
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
        public Guid EmployeeId { get; set; }

        //Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
