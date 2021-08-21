namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodCategoryValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodCategories", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodCategories", "Name", c => c.String());
        }
    }
}
