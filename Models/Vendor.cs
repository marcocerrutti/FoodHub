using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodHub.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        [Display(Name="Vendor Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Food> Foods { get; set; }

        public virtual ICollection<VendorImageMapping> VendorImageMappings { get; set; }
    }
}