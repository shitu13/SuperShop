using Microsoft.AspNetCore.Mvc;
using SuperShop.Models;
using SuperShop.DataAccess.Data;

namespace SuperShopWeb.Controllers
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
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        //For Editing an element

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["update"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //For deteleing an element

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["delete"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
