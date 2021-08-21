using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class FoodImageMapping
    {
        public int Id { get; set; }
        public int ImageNumber { get; set; }
        public int FoodId { get; set; }
        public int FoodImageId { get; set; }
        public virtual Food Food { get; set; }
        public virtual FoodImage FoodImage { get; set; }
    }
}