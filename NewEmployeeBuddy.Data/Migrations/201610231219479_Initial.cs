namespace NewEmployeeBuddy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        PhoneNumber = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        MobileNumber = c.String(),
                        EmailAddress = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        PinCode = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Id = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
        }
    }
}
