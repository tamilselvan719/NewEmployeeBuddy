using System;

namespace NewEmployeeBuddy.Data.Entities.Base
{
    /// <summary>
    /// To provide a base layout of properties used in most of the Models; thus avoids code duplications
    /// </summary>
    public abstract class BaseEntity
    {
        //public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
