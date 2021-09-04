using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodHub.DAL;
using FoodHub.Models;
using FoodHub.ViewModels;
using PagedList;

namespace FoodHub.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FoodsController : Controller
    {
        private FoodContext db = new FoodContext();

        // GET: Foods
        [AllowAnonymous]
        public ActionResult Index(string category, string vendor, string search, string sortBy, int? page)
        {

            //instantiate a new view Model
            FoodIndexViewModel viewModel = new FoodIndexViewModel();

            var foods = db.Foods.Include(f => f.FoodCategory).Include(f => f.Vendor);
            if (!String.IsNullOrEmpty(category))
            {
                foods = foods.Where(p => p.FoodCategory.Name == category);
               
            }

            if (!String.IsNullOrEmpty(vendor))
            {
                foods = foods.Where(v => v.Vendor.Name == vendor);

            }

            if (!String.IsNullOrEmpty(search))
            {
                foods = foods.Where(f => f.Name.Contains(search) ||
                f.Description.Contains(search) ||
                f.FoodCategory.Name.Contains(search));
                viewModel.Search = search;
            }

            //group search results into categories and count how many items in each category
            viewModel.CatsWithCount = from matchingFoods in foods
                                      where
                                      matchingFoods.FoodCategoryId != null
                                      group matchingFoods by
                                      matchingFoods.FoodCategory.Name into
                                      catGroup
                                      select new CategoryWithCount()
                                      {
                                          FoodCategoryName = catGroup.Key,
                                          FoodCount = catGroup.Count()
                                      };

            //group search results into vendors and count how many items in each vendor
            viewModel.VendWithCount = from matchingVendors in foods
                                      where
                                      matchingVendors.VendorId != null
                                      group matchingVendors by
                                      matchingVendors.Vendor.Name into
                                      vendGroup
                                      select new VendorWithCount()
                                      {
                                          VendorName = vendGroup.Key,
                                          FoodCount = vendGroup.Count()
                                      };

            // var categories = foods.OrderBy(f => f.FoodCategory.Name).Select(f => 
            //f.FoodCategory.Name).Distinct();

            if (!String.IsNullOrEmpty(category))
            {
                foods = foods.Where(p => p.FoodCategory.Name == category);
                viewModel.FoodCategory = category;
            }

            var vendors = foods.OrderBy(v => v.Vendor.Name).Select(v => 
            v.Vendor.Name).Distinct();

            if (!String.IsNullOrEmpty(vendor))
            {
                foods = foods.Where(p => p.Vendor.Name == vendor);
                viewModel.Vendor = vendor;
            }

            //sort the results
            switch (sortBy)
            {
                case "price_lowest":
                    foods = foods.OrderBy(p => p.Price);
                    break;
                case "price_highest":
                   foods = foods.OrderByDescending(p => p.Price);
                    break;
                default:
                    foods = foods.OrderBy(p => p.Name);
                    break;
            }

            //ViewBag.FoodCategory = new SelectList(categories);
            // viewModel.Foods = foods;
            // ViewBag.Vendor = new SelectList(vendors);

           
            int currentPage = (page ?? 1);
            viewModel.Foods = foods.ToPagedList(currentPage, Constants.PageItems);
            viewModel.SortBy = sortBy;
            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Price low to high", "price_lowest" },
                {"Price high to low", "price_highest" }
            };


            return View(viewModel);
        }

        // GET: Foods/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Foods/Create

            public ActionResult Create()
            {
                FoodViewModel viewModel = new FoodViewModel();
                viewModel.FoodCategoryList = new SelectList(db.FoodCategories, "Id", "Name");
                viewModel.VendorList = new SelectList(db.Vendors, "Id", "Name");
                viewModel.ImageLists = new List<SelectList>();
                for (int i = 0; i < Constants.NumberOfFoodImages; i++)
                {
                    viewModel.ImageLists.Add(new SelectList(db.FoodImages, "Id", "FileName"));
                }
                return View(viewModel);


                //ViewBag.FoodCategoryId = new SelectList(db.FoodCategories, "Id", "Name");
                //ViewBag.VendorId = new SelectList(db.Vendors, "Id", "Name");
                //return View();
            }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodViewModel viewModel)
        {
            Food food = new Food();
            food.Name = viewModel.Name;
            food.Description = viewModel.Description;
            food.Price = viewModel.Price;
            food.FoodCategoryId = viewModel.FoodCategoryId;
            food.VendorId = viewModel.VendorId;
            food.FoodImageMappings = new List<FoodImageMapping>();

            //get a list of selected images without any blanks
            string[] foodImages = viewModel.FoodImages.Where(pi =>
            !string.IsNullOrEmpty(pi)).ToArray();
            for (int i = 0; i < foodImages.Length; i++)
            {
                food.FoodImageMappings.Add(new FoodImageMapping
                {
                    FoodImage = db.FoodImages.Find(int.Parse(foodImages[i])),
                    ImageNumber = i
                });
            }
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.FoodCategoryList = new SelectList(db.FoodCategories, "Id", "Name", food.FoodCategoryId);
            viewModel.VendorList = new SelectList(db.Vendors, "Id", "Name", food.VendorId);
            viewModel.ImageLists = new List<SelectList>();
            for (int i = 0; i < Constants.NumberOfFoodImages; i++)
            {
                viewModel.ImageLists.Add(new SelectList(db.FoodImages, "ID", "FileName",
                viewModel.FoodImages[i]));
            }
            return View(viewModel);
        }

        // GET: Foods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }

            FoodViewModel viewModel = new FoodViewModel();
            viewModel.FoodCategoryList = new SelectList(db.FoodCategories, "Id", "Name", food.FoodCategoryId);
            viewModel.VendorList = new SelectList(db.Vendors, "Id", "Name", food.VendorId);
            viewModel.ImageLists = new List<SelectList>();
            foreach (var imageMapping in food.FoodImageMappings.OrderBy(pim => pim.ImageNumber))
            {
                viewModel.ImageLists.Add(new SelectList(db.FoodImages, "Id", "FileName",
                imageMapping.FoodImageId));
            }
            for (int i = viewModel.ImageLists.Count; i < Constants.NumberOfFoodImages; i++)
            {
                viewModel.ImageLists.Add(new SelectList(db.FoodImages, "Id", "FileName"));
            }
            viewModel.Id = food.Id;
            viewModel.Name = food.Name;
            viewModel.Description = food.Description;
            viewModel.Price = food.Price;
            return View(viewModel);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,FoodCategoryId,VendorId")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodCategoryId = new SelectList(db.FoodCategories, "Id", "Name", food.FoodCategoryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "Name", food.VendorId);
            return View(food);
        }

        // GET: Foods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
