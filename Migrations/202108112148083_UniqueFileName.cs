namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueFileName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodImages", "FileName", c => c.String(maxLength: 100));
            CreateIndex("dbo.FoodImages", "FileName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.FoodImages", new[] { "FileName" });
            AlterColumn("dbo.FoodImages", "FileName", c => c.String());
        }
    }
}
