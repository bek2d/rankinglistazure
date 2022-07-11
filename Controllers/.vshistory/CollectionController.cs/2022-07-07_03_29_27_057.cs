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
            return RedirectToAction("Index", "Item", new { @CollectionId = id });
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
    }
}
