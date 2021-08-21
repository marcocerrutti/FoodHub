using FoodHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class FoodCategoryImageMapping
    {
        public int Id { get; set; }
        public int ImageNumber { get; set; }
        public int FoodCategoryId { get; set; }
        public int FoodCategoryImageId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
        public virtual FoodCategoryImage FoodCategoryImage { get; set; }
    }
}