using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.ViewModels
{
    public class FoodCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The category name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a category name between 3 and 50 characters in length")]
        [RegularExpression(@"^[a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a product name made up of letters and numbers only")]
        public string Name { get; set; }

        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s]*$", ErrorMessage = "Please enter a productdescription made up of letters and numbers only")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int FoodCategoryId { get; set; }

       // public SelectList FoodCategoryList { get; set; }

        public List<SelectList> ImageLists { get; set; }

        public string[] FoodCategoryImages { get; set; }


    }
}