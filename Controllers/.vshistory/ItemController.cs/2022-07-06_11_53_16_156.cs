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

       

        public IActionResult Index(int id)
        {
            Item item = _db.Items.Find(id);
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
        [Route("set-default-favorite")]
       
        public IActionResult Create(Item model)
        {
            var a = model.Id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create(Item Name, Item CollectionId)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(Name);
                _db.Items.Add(CollectionId);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Name);

        }
    }
}
