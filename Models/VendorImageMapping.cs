using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHub.Models
{
    public class VendorImageMapping
    {
        public int Id { get; set; }
        public int ImageNumber { get; set; }
        public int VendorId { get; set; }
        public int VendorImageId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual VendorImage VendorImage { get; set; }
    }
}