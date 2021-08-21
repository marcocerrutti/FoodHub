using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class VendorImage
    {
        public int Id { get; set; }
        [Display(Name = "File")]
        public string FileName { get; set; }

        public virtual ICollection<VendorImageMapping> VendorImageMappings { get; set; }
    }
}