namespace FoodHub.Migrations.FoodConfiguration
{
    using FoodHub.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class FoodConfiguration : DbMigrationsConfiguration<FoodHub.DAL.FoodContext>
    {
        public FoodConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FoodHub.DAL.FoodContext";
        }

        protected override void Seed(FoodHub.DAL.FoodContext context)
        {
            var categories = new List<FoodCategory>
            {
            new FoodCategory { Name = "Continental" },
            new FoodCategory { Name = "African Cusine" },
            new FoodCategory { Name = "FastFood" },
            new FoodCategory { Name = "Chinese Asian" },
            new FoodCategory { Name= "Italian" },
            new FoodCategory { Name= "Lebanese" },
            new FoodCategory { Name= "Drinks" }
            };
            categories.ForEach(c => context.FoodCategories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var vendors = new List<Vendor>
            {
                new Vendor { Name = "KFC", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "BluCubana", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "Wakkis", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "Zuma Grill", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "Jevnik", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "Johnny Rockets", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "Bukka Resturant", Address="For sleeping or general wear",Email="info@kfc.com"},
                new Vendor { Name = "The Cube Cafe", Address="For sleeping or general wear",Email="info@kfc.com"},
            };
            vendors.ForEach(c => context.Vendors.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var foods = new List<Food>
            {
            new Food { Name = "Pot Roast", Description="Braised beef and vegetable",Price=4.99M, FoodCategoryId=categories.Single( c => c.Name == "Continental").Id ,VendorId = vendors.Single(c => c.Name == "Wakkis").Id},
            new Food { Name = "Key lime pie", Description="Key lime pie is a staple on south Florida menus", Price=2.99M, FoodCategoryId=categories.Single( c => c.Name =="Continental").Id, VendorId = vendors.Single(c => c.Name == "BluCubana").Id },
            new Food { Name = "Tatar tots", Description="Tater tots are crunchy fried potatoes", Price=1.99M, FoodCategoryId=categories.Single( c => c.Name =="Chinese Asian").Id, VendorId = vendors.Single(c => c.Name == "Zuma Grill").Id },
            new Food { Name = "Jambalaya", Description="Baby comforter", Price=2.99M,FoodCategoryId=categories.Single(c => c.Name == "African Cusine").Id, VendorId = vendors.Single(c => c.Name == "Jevnik").Id},
            new Food { Name = "Biscuits and Gravy", Description="For a leak freedrink everytime", Price=24.99M, FoodCategoryId=categories.Single( c => c.Name == "African Cusine").Id, VendorId = vendors.Single(c => c.Name == "Johnny Rockets").Id},
            new Food { Name = "Wild Alaska salmon", Description = "Salmon is delicious and nutritious", Price=8.99M, FoodCategoryId=categories.Single( c => c.Name == "Chinese Asian").Id, VendorId = vendors.Single(c => c.Name == "Bukka Resturant").Id},
            new Food{ Name = "Okpa", Description = "Nutritional and Tasty", Price=9.99M, FoodCategoryId=categories.Single( c => c.Name =="Chinese Asian").Id, VendorId = vendors.Single(c => c.Name == "Jevnik").Id},
            new Food{Name = "Moi Moi", Description = "Delicious Bean Cake", Price=19.99M, FoodCategoryId=categories.Single(c => c.Name == "Lebanese").Id, VendorId = vendors.Single(c => c.Name == "Jevnik").Id},
            new Food{ Name = "Eba and Egusi",Description = "For helping with babycolic pains", Price=4.99M, FoodCategoryId=categories.Single( c => c.Name == "Lebanese").Id, VendorId = vendors.Single(c => c.Name == "BluCubana").Id},
            new Food{ Name = "Goat Meat Peppersoup",Description = "Spicy and Delicious beef meal", Price=4.99M, FoodCategoryId=categories.Single(c => c.Name == "Lebanese").Id,  VendorId = vendors.Single(c => c.Name == "KFC").Id},
            new Food{ Name = "Fried Rice", Description = "Mouth Watering Dish", Price=299.99M, FoodCategoryId=categories.Single(c => c.Name == "FastFood").Id, VendorId = vendors.Single(c => c.Name == "BluCubana").Id},
            new Food{ Name = "Pepper Chicken",Description = "For safe car travel", Price = 49.99M, FoodCategoryId = categories.Single(c => c.Name =="FastFood").Id, VendorId = vendors.Single(c => c.Name == "Johnny Rockets").Id},
            new Food {Name = "Cioppino", Description = "Portugal meets meets Italy meets France by way of San Francisco",Price = 75.99M,FoodCategoryId = categories.Single(c => c.Name =="FastFood").Id, VendorId = vendors.Single(c => c.Name == "Johnny Rockets").Id},
            new Food{Name = "Baked Beans", Description = "Baked beans popularity in Boston lead to the nickname 'Beantown",Price = 35.99M,FoodCategoryId = categories.Single(c => c.Name == "Italian").Id, VendorId = vendors.Single(c => c.Name == "Wakkis").Id},
            new Food{Name = "Fruit Salad", Description = "light meal taken between meals", Price=149.99M, FoodCategoryId=categories.Single( c => c.Name == "Continental").Id, VendorId = vendors.Single(c =>c.Name =="Wakkis").Id},
            new Food{ Name = "Cocacola",Description = "Carbonated Drink", Price=29.99M, FoodCategoryId=categories.Single( c => c.Name =="Drinks").Id, VendorId = vendors.Single(c =>c.Name =="The Cube Cafe").Id}, 
            new Food {Name = "Buffalo Wings",Description = "Buffalo wings are coated in cayenne pepper and hot sauce", Price=35.99M, FoodCategoryId=categories.Single( c =>c.Name == "Continental").Id, VendorId = vendors.Single(c => c.Name == "The Cube Cafe").Id },
           };
           foods.ForEach(c => context.Foods.AddOrUpdate(p => p.Name, c));
           context.SaveChanges();
         

        }
    }
}

