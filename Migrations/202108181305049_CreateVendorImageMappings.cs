namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVendorImageMappings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorImageMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageNumber = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        VendorImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("dbo.VendorImages", t => t.VendorImageId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.VendorImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendorImageMappings", "VendorImageId", "dbo.VendorImages");
            DropForeignKey("dbo.VendorImageMappings", "VendorId", "dbo.Vendors");
            DropIndex("dbo.VendorImageMappings", new[] { "VendorImageId" });
            DropIndex("dbo.VendorImageMappings", new[] { "VendorId" });
            DropTable("dbo.VendorImageMappings");
        }
    }
}
