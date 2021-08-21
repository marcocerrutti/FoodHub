using FoodHub.Models;
using System.Data.Entity;

namespace FoodHub.DAL
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<FoodImage> FoodImages { get; set; }

        public DbSet<VendorImage> VendorImages { get; set; }

        public DbSet<FoodCategoryImage> FoodCategoryImages { get; set; }
        public DbSet<FoodImageMapping> FoodImageMappings { get; set; }
        public DbSet<FoodCategoryImageMapping> FoodCategoryImageMappings { get; set; }
        public DbSet<VendorImageMapping> VendorImageMappings { get; set; }

    }
}