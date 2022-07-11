using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcAppCollect.Models;
using MvcAppCollect.Data;

namespace MvcAppCollect.Controllers
{
    //[Route("[controller]/[action]")]
    public class ItemController : Controller


    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index(int CollectionId)
        {
            var a = CollectionId.ToString();
            ViewBag.Value = a;

            IEnumerable<Item> item = _db.Items.FromSqlRaw("SELECT * FROM dbo.Items WHERE CollectionId = {0}", CollectionId).ToList();

            return View(item);

        }


        [Route("[controller]/[action]")]

        public IActionResult Middleware(int Id)
        {

            return RedirectToAction("Create", new { @CollectionId = Id });
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
            return RedirectToAction("Index");


            return View(obj);

        }
    }
}
