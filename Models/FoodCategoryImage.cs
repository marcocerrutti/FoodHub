using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FoodHub. Models;

namespace FoodHub.DAL
{
    public class FoodCategoryImage
    {
        public int Id { get; set; }
        [Display(Name = "File")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string FileName { get; set; }

        public virtual ICollection<FoodCategoryImageMapping> FoodCategoryImageImageMappings { get; set; }
    }
}