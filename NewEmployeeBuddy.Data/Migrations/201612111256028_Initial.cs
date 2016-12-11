namespace NewEmployeeBuddy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Address",
                c => new
                    {
                        AddressId = c.Guid(nullable: false),
                        House = c.String(),
                        Ward = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PinCode = c.String(),
                        AreaCode = c.String(),
                        Landmark = c.String(),
                        EmployeeId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.tbl_Employee", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.tbl_Employee",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        AddressId = c.Guid(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        PayrollId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tbl_Contact",
                c => new
                    {
                        ContactId = c.Guid(nullable: false),
                        Landline = c.String(),
                        Mobile = c.String(),
                        Fax = c.String(),
                        EmailAddress = c.String(),
                        EmployeeId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.tbl_Employee", t => t.ContactId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.tbl_Payroll",
                c => new
                    {
                        PayrollId = c.Guid(nullable: false),
                        BasicPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FlexiblePay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PFContribution = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Allowances = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.PayrollId)
                .ForeignKey("dbo.tbl_Employee", t => t.PayrollId)
                .Index(t => t.PayrollId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Address", "AddressId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Payroll", "PayrollId", "dbo.tbl_Employee");
            DropForeignKey("dbo.tbl_Contact", "ContactId", "dbo.tbl_Employee");
            DropIndex("dbo.tbl_Payroll", new[] { "PayrollId" });
            DropIndex("dbo.tbl_Contact", new[] { "ContactId" });
            DropIndex("dbo.tbl_Address", new[] { "AddressId" });
            DropTable("dbo.tbl_Payroll");
            DropTable("dbo.tbl_Contact");
            DropTable("dbo.tbl_Employee");
            DropTable("dbo.tbl_Address");
        }
    }
}
