using NewEmployeeBuddy.Data.Entities.Employee;
using System.Data.Entity.ModelConfiguration;

namespace NewEmployeeBuddy.Data.Configurations
{
    /// <summary>
    /// To configure the Employee model using Fluent API provided by Entity Framework
    /// </summary>
    public class EmployeeConfiguration: EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeId);

            // Table & Column Mappings
            this.ToTable("Employee");
            this.Property(p => p.EmployeeId).HasColumnOrder(0).IsRequired();
            this.Property(p => p.FirstName).HasColumnOrder(1).IsUnicode().IsMaxLength();
            this.Property(p => p.MiddleName).HasColumnOrder(2).IsUnicode().IsMaxLength();
            this.Property(p => p.LastName).HasColumnOrder(3).IsUnicode().IsMaxLength();
            this.Property(p => p.DateOfBirth).HasColumnOrder(4).HasColumnType("datetime");
            this.Property(p => p.Gender).HasColumnOrder(5).IsUnicode().IsMaxLength();
            this.Property(p => p.IsActive).HasColumnOrder(6).IsOptional();

            this.Property(p => p.PayrollId).HasColumnOrder(7).IsRequired();
            this.Property(p => p.AddressId).HasColumnOrder(8).IsRequired();
            this.Property(p => p.ContactId).HasColumnOrder(9).IsRequired();

            this.Property(p => p.CreatedBy).IsUnicode();
            this.Property(p => p.CreatedOn).HasColumnType("datetime");
            this.Property(p => p.UpdatedBy).IsUnicode();
            this.Property(p => p.UpdatedOn).HasColumnType("datetime");

        }
}
}
