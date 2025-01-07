namespace WebTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Adv", "Alias", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Adv", "Link", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Adv", "Link", c => c.String(maxLength: 500));
            DropColumn("dbo.tb_Adv", "Alias");
        }
    }
}
