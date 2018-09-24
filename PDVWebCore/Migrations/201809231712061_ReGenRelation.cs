namespace PDVWebCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReGenRelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustomerCustomerRole");
            AddPrimaryKey("dbo.CustomerCustomerRole", new[] { "CustomerRoleID", "Username" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustomerCustomerRole");
            AddPrimaryKey("dbo.CustomerCustomerRole", new[] { "Username", "CustomerRoleID" });
        }
    }
}
