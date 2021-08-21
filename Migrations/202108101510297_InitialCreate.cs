namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodCategoryId = c.Int(),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategoryId)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.FoodCategoryId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        FoodCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategory_Id)
                .Index(t => t.FoodCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendors", "FoodCategory_Id", "dbo.FoodCategories");
            DropForeignKey("dbo.Foods", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Foods", "FoodCategoryId", "dbo.FoodCategories");
            DropIndex("dbo.Vendors", new[] { "FoodCategory_Id" });
            DropIndex("dbo.Foods", new[] { "VendorId" });
            DropIndex("dbo.Foods", new[] { "FoodCategoryId" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodCategories");
        }
    }
}
