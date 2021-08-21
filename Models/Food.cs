using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The food name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a food name between 3 and 50 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a food name made up of letters and numbers only")]
        [Display(Name="Food Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The food description cannot be blank")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Please enter a food description between 10 and 200 characters in length")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a food description made up of letters and numbers only")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Required(ErrorMessage = "The price cannot be blank")]
        [Range(0.10, 10000, ErrorMessage = "Please enter a price between 0.10 and 10000.00")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [RegularExpression("[0-9]+(\\.[0-9][0-9]?)?", ErrorMessage = "The price must be a number up to two decimal places")]
        public decimal Price { get; set; }
        public int? FoodCategoryId { get; set; }
        public int VendorId { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
        public virtual Vendor Vendor { get; set; }

        public virtual ICollection<FoodImageMapping> FoodImageMappings { get; set; }
    }
}