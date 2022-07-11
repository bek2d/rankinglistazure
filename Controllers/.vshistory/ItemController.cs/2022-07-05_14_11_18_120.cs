using Microsoft.AspNetCore.Mvc;
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
        
        //[HttpGet("{CollectionId}")]
        public IActionResult Index(int id)
        {
            Item collection = _db.Items.Find(id);
            return View(collection);
           
        }
    }
}
