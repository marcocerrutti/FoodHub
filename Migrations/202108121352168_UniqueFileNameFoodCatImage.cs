namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueFileNameFoodCatImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodCategoryImages", "FileName", c => c.String(maxLength: 100));
            CreateIndex("dbo.FoodCategoryImages", "FileName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.FoodCategoryImages", new[] { "FileName" });
            AlterColumn("dbo.FoodCategoryImages", "FileName", c => c.String());
        }
    }
}
