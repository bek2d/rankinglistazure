using Microsoft.AspNetCore.Mvc;
using MvcAppCollect.Data;
using MvcAppCollect.Models;

namespace MvcAppCollect.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CollectionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Collection> objCollectionsList = _db.Collections;
            return View(objCollectionsList);
        }

        public IActionResult Open(int id)
        {
            return RedirectToAction("Check", "Item");
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Collection obj)
        {
            if (ModelState.IsValid)
            {
                _db.Collections.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Collections.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Collections.Find(id);
            _db.Collections.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


            return View(obj);

        }

    }
}
