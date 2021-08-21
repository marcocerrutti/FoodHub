using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class FoodImage
    {
        public int Id { get; set; }

        [Display(Name ="File")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string FileName { get; set; }

        public virtual ICollection<FoodImageMapping> FoodImageMappings { get; set; }
    }
}