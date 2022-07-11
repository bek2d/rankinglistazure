using Microsoft.AspNetCore.Mvc;
using MvcAppCollect.Models;
using MvcAppCollect.Data;

namespace MvcAppCollect.Controllers
{
    [Route("[controller]/[action]")]
    public class ItemController : Controller


    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{Id}")]
        public string Get(int id)
        {
            return $"my id {id}";
        }

        public IActionResult Index(int id)
        {
            Item item = _db.Items.Find(id);
            return View(item);
           
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }
    }
}
