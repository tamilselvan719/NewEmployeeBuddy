using NewEmployeeBuddy.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEmployeeBuddy.Data.Entities.Employee
{
    [Table("tbl_Contact")]
    public class Contact: BaseEntity
    {
        [Key, ForeignKey("Employee")]
        public Guid ContactId { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public Guid EmployeeId { get; set; }

        //Navigation Properties
        public virtual Employee Employee { get; set; }
    }
}
