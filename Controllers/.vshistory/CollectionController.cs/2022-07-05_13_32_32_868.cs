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

        public IActionResult Open(int CollectionId)
        {
            Collection collection = _db.Collections.Find(CollectionId);
            return RedirectToAction("Index", "Item", new { variable = 1 });
        }        
    }
}
