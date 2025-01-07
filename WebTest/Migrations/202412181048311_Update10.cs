namespace WebTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_News", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_News", "Link");
        }
    }
}
