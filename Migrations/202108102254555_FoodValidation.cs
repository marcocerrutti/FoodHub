namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Foods", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Description", c => c.String());
            AlterColumn("dbo.Foods", "Name", c => c.String());
        }
    }
}
