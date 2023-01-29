﻿using LakshmiMovieApp.Data;
using LakshmiMovieApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LakshmiMovieApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;


        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order cannot be exactly same");
            }
            if (ModelState.IsValid)
            { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Catgegory created successfully";
             return RedirectToAction("Index");
        }
            return View(obj);
        }








        public IActionResult GetCategorybyid (int? id)
        {

            var details = _db.Categories.FromSqlRaw<Category>("SP_GetCategorybyid {0}", id).ToList().FirstOrDefault();
            if (details == null) return View("Empty");

            return View(details);
        }




















        public IActionResult Edit(int? id)
        {

            if (id ==null || id == 0){

                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {

                return NotFound();

            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order cannot be exactly same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Catgegory Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }







        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {

                return NotFound();

            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id )
        {

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {

                return NotFound();

            }
               _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Catgegory Deleted successfully";
            return RedirectToAction("Index");
          
          
        }














    }
}
