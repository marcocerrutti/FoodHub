namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductImageMappings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodImageMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        FoodImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.FoodImages", t => t.FoodImageId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.FoodImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodImageMappings", "FoodImageId", "dbo.FoodImages");
            DropForeignKey("dbo.FoodImageMappings", "FoodId", "dbo.Foods");
            DropIndex("dbo.FoodImageMappings", new[] { "FoodImageId" });
            DropIndex("dbo.FoodImageMappings", new[] { "FoodId" });
            DropTable("dbo.FoodImageMappings");
        }
    }
}
