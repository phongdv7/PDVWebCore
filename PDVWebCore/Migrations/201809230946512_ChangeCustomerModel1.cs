namespace PDVWebCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomerModel1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customer", newName: "User");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.User", newName: "Customer");
        }
    }
}
