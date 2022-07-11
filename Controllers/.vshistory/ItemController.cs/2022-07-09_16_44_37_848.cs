using System.s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcAppCollect.Models;
using MvcAppCollect.Data;

namespace MvcAppCollect.Controllers
{
    
    public class ItemController : Controller


    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
      
        public IActionResult Check(int Id)
        {
            if (Id == 0 || Id == null)
            {
                return RedirectToAction("Middleware", new { Id = Id });
            }
            var categoryFromDb = _db.Items.Find(Id);
            if (categoryFromDb == null)
            {
                return RedirectToAction("Middleware", new { Id = Id });
            }
            return RedirectToAction("Index", new { Id = Id });
        }

        public IActionResult Index(int Id)
        {
            var a = Id.ToString();
            ViewBag.Value = a;

            IEnumerable<Item> item = _db.Items.FromSqlRaw("SELECT * FROM dbo.Items WHERE Id = {0}", Id).ToList();

            return View(item);

        }


        

        public IActionResult Middleware(int Id)
        {

            return RedirectToAction("Create", new { Id = Id });
        }


        //[HttpGet("{Id}")]
        public IActionResult Create(int Id)
        {
            return View();
        }

        [HttpPost]
       
        [ValidateAntiForgeryToken]


        public IActionResult Create(Item Id)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(Id);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Items.Find(id);
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
            var obj = _db.Items.Find(id);
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new {Id = id});


            return View(obj);

        }

      
    }
}
