namespace WebTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveToServiceCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ServiceCategory", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ServiceCategory", "IsActive");
        }
    }
}
