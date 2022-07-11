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
            //item = _db.Items.Where(a => a.CollectionId == 3).ToList();
            ViewBag.Value = CollectionId;

            IEnumerable <Item>  item= _db.Items.FromSqlRaw("SELECT * FROM dbo.Items WHERE CollectionId = {0}", CollectionId).ToList();

            
            return View(item);
           
        }

        //[HttpGet()]
        //public IActionResult Get(Item model)
        //{
        //    return View();
        //}
        //[HttpGet("{Id}")]
        //public string Get(int id)
        //{
        //    return $"my id {id}";
        //}
        // [HttpGet("{Id}")]

        public IActionResult Middleware(int CollectionId)
        {

            return RedirectToAction("Create", new { @CollectionId = CollectionId });
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
    }
}
