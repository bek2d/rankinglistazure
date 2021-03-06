using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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



        public IActionResult Index(int Id)
        {
            //item = _db.Items.Where(a => a.CollectionId == 3).ToList();

            IEnumerable <Item>  item= _db.Items.FromSqlRaw("SELECT * FROM dbo.Items WHERE CollectionFK = {0}", Id).ToList();

            return View(item);
           
        }

        [HttpGet()]
        public IActionResult Get(Item model)
        {
            return View();
        }
        //[HttpGet("{Id}")]
        //public string Get(int id)
        //{
        //    return $"my id {id}";
        //}
        // [HttpGet("{Id}")]

        public IActionResult Middleware(int id)
        {
            
            return RedirectToAction("Create",  new { @id = id });
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
                _db.Items.FromSqlRaw("SET IDENTITY_INSERT ON");
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
