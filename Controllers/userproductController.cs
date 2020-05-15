//using Ghardailo.Data;
//using Ghardailo.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//namespace Ghardailo.Controllers
//{
//    public class userproductController:Controller

//    {
//        private ApplicationDbContext db;
//        private IWebHostEnvironment env;
//        public userproductController(ApplicationDbContext _db,
//            IWebHostEnvironment _env)

//        {
//            db = _db;
//            env = _env;
//        }
//        public IActionResult Create()
//        {
//            ViewBag.CategoryList = new SelectList(db.Cateogry, "CategoryId", "CategoryName", "Description");
//            return View();
//        }



//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Product_Details bike)
//        {
//            if (ModelState.IsValid)   // it will check whether our form is valid or not
//            {
//                if (bike.BikeImage != null)
//                {
//                    string rootPath = env.WebRootPath;                    // get the root directory i.e. /wwwroot/
//                    string uniqueName = Guid.NewGuid().ToString();

//                    string fileName = uniqueName + bike.BikeImage.FileName;      // file uploaded name
//                    string uploadPath = rootPath + "~/Images/" + fileName;       // creating upload path
//                    bike.Product_Image = fileName;                                 // assing file name to bike>imagename                                                                                    
//                    using (var filestream = new FileStream(uploadPath, FileMode.Create))
//                    {
//                        await bike.BikeImage.CopyToAsync(filestream);
//                    }
//                }
//                db.Add(bike);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(bike);
//        }



//        public async Task<IActionResult> Index()
//        {
//            var query = from b in db.Product_Details
//                        join c in db.Cateogry
//                        on b.CategoryId equals c.CategoryId
//                        select new Product_Details
//                        {
//                            Product_id = b.Product_id,
//                            Product_Name = b.Product_Name,
//                            Product_Price = b.Product_Price,
//                            Stock = b.Stock,
//                            Manufacture_Date = b.Manufacture_Date,
//                            Expire_Date = b.Expire_Date,
//                            BikeImage=b.BikeImage,

//                            CategoryName = c.CategoryName
//                        };

//            // select * from bikes 
//            List<Product_Details> prod = query.ToList();  // ORM EF Core
//            return View(prod);
//        }

//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var bike = await db.Product_Details.FindAsync(id);
//            if (bike == null)
//            {
//                return NotFound();
//            }

//            return View(bike);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var bike = await db.Product_Details.FindAsync(id);
//            if (bike == null)
//            {
//                return NotFound();
//            }
//            return View(bike);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(Product_Details prodi)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Update(prodi);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(prodi);
//        }

//        public IActionResult Delete(int id)
//        {
//            // where bikeid = id
//            Product_Details produi = db.Product_Details.Find(id);
//            db.Product_Details.Remove(produi);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//    }
//}
