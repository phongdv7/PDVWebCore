namespace PDVWebCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerModel", newName: "Customer");
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Customer", "Company", c => c.String(maxLength: 500));
            AlterColumn("dbo.Customer", "StreetAddress", c => c.String(maxLength: 500));
            AlterColumn("dbo.Customer", "StreetAddress2", c => c.String(maxLength: 500));
            AlterColumn("dbo.Customer", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customer", "Phone", c => c.String(maxLength: 15));
            AlterColumn("dbo.Customer", "LastIpAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customer", "LastVisitedPage", c => c.String(maxLength: 500));
            AddPrimaryKey("dbo.Customer", "Username");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "LastVisitedPage", c => c.String());
            AlterColumn("dbo.Customer", "LastIpAddress", c => c.String());
            AlterColumn("dbo.Customer", "Phone", c => c.String());
            AlterColumn("dbo.Customer", "City", c => c.String());
            AlterColumn("dbo.Customer", "StreetAddress2", c => c.String());
            AlterColumn("dbo.Customer", "StreetAddress", c => c.String());
            AlterColumn("dbo.Customer", "Company", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customer", "Username");
            RenameTable(name: "dbo.Customer", newName: "CustomerModel");
        }
    }
}
