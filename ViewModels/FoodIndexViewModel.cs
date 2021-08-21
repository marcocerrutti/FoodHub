using FoodHub.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.ViewModels
{
    public class FoodIndexViewModel
    {
        public IPagedList<Food>Foods { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string FoodCategory { get; set; }

        public string Vendor { get; set; }
        public IEnumerable<VendorWithCount> VendWithCount { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }

        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.FoodCategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }

        public IEnumerable<SelectListItem> VendFilterItems
        {
            get
            {
                var allVends = VendWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.VendorName,
                    Text = cc.VendNameWithCount
                });
                return allVends;
            }
        }

    }

    public class CategoryWithCount
    {
        public int FoodCount { get; set; }
        public string FoodCategoryName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return FoodCategoryName + " (" + FoodCount.ToString() + ")";
            }
        }
    }

    public class VendorWithCount
    {
        public int FoodCount { get; set; }
        public string VendorName { get; set; }
        public string VendNameWithCount
        {
            get
            {
                return VendorName + " (" + FoodCount.ToString() + ")";
            }
        }
    }
}