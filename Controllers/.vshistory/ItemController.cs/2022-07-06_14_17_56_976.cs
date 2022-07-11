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

       

        public IActionResult Index(int Id)
        {
            int item = _db.Items.Where(Id => Id.CollectionId == Id);

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
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
