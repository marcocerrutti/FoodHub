namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFoodCategoryImageMappings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendors", "FoodCategory_Id", "dbo.FoodCategories");
            DropIndex("dbo.Vendors", new[] { "FoodCategory_Id" });
            CreateTable(
                "dbo.FoodCategoryImageMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        FoodCategoryId = c.Int(nullable: false),
                        FoodCategoryImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.FoodCategoryImages", t => t.FoodCategoryImageId, cascadeDelete: true)
                .Index(t => t.FoodCategoryId)
                .Index(t => t.FoodCategoryImageId);
            
            DropColumn("dbo.Vendors", "FoodCategory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "FoodCategory_Id", c => c.Int());
            DropForeignKey("dbo.FoodCategoryImageMappings", "FoodCategoryImageId", "dbo.FoodCategoryImages");
            DropForeignKey("dbo.FoodCategoryImageMappings", "FoodCategoryId", "dbo.FoodCategories");
            DropIndex("dbo.FoodCategoryImageMappings", new[] { "FoodCategoryImageId" });
            DropIndex("dbo.FoodCategoryImageMappings", new[] { "FoodCategoryId" });
            DropTable("dbo.FoodCategoryImageMappings");
            CreateIndex("dbo.Vendors", "FoodCategory_Id");
            AddForeignKey("dbo.Vendors", "FoodCategory_Id", "dbo.FoodCategories", "Id");
        }
    }
}
