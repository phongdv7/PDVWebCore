namespace PDVWebCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModel",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        VendorId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Company = c.String(),
                        StreetAddress = c.String(),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                        Active = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        LastActivityDate = c.DateTime(nullable: false),
                        LastIpAddress = c.String(),
                        LastVisitedPage = c.String(),
                        CustomerRoleNames = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerModel");
        }
    }
}
