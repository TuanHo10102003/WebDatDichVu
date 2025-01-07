namespace WebTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "CustomerId", c => c.String());
            AddColumn("dbo.tb_Order", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "Status");
            DropColumn("dbo.tb_Order", "CustomerId");
        }
    }
}
