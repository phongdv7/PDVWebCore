namespace PDVWebCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerRole",
                c => new
                    {
                        CustomerRoleID = c.Int(nullable: false, identity: true),
                        RoleCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 200),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerRoleID);
            
            CreateTable(
                "dbo.CustomerCustomerRole",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        CustomerRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Username, t.CustomerRoleID })
                .ForeignKey("dbo.Customer", t => t.Username, cascadeDelete: true)
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRoleID, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.CustomerRoleID);
            
            DropColumn("dbo.Customer", "CustomerRoleNames");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "CustomerRoleNames", c => c.String());
            DropForeignKey("dbo.CustomerCustomerRole", "CustomerRoleID", "dbo.CustomerRole");
            DropForeignKey("dbo.CustomerCustomerRole", "Username", "dbo.Customer");
            DropIndex("dbo.CustomerCustomerRole", new[] { "CustomerRoleID" });
            DropIndex("dbo.CustomerCustomerRole", new[] { "Username" });
            DropTable("dbo.CustomerCustomerRole");
            DropTable("dbo.CustomerRole");
        }
    }
}
