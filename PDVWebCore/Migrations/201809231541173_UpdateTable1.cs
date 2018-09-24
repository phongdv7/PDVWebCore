namespace PDVWebCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "VendorId", c => c.Int());
            AlterColumn("dbo.Customer", "LastActivityDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "LastActivityDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "VendorId", c => c.Int(nullable: false));
        }
    }
}
