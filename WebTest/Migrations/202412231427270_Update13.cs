namespace WebTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Adv", "Detail", c => c.String());
            AddColumn("dbo.tb_Adv", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Adv", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_Adv", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Adv", "Description", c => c.String());
            AlterColumn("dbo.tb_Adv", "Image", c => c.String());
            AlterColumn("dbo.tb_Adv", "Alias", c => c.String());
            CreateIndex("dbo.tb_Adv", "CategoryId");
            AddForeignKey("dbo.tb_Adv", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_Adv", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Adv", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_Adv", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Adv", new[] { "CategoryId" });
            AlterColumn("dbo.tb_Adv", "Alias", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Adv", "Image", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Adv", "Description", c => c.String(maxLength: 500));
            DropColumn("dbo.tb_Adv", "SeoKeywords");
            DropColumn("dbo.tb_Adv", "SeoDescription");
            DropColumn("dbo.tb_Adv", "SeoTitle");
            DropColumn("dbo.tb_Adv", "Detail");
        }
    }
}
