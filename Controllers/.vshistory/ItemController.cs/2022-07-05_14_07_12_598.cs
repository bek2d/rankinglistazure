using Microsoft.AspNetCore.Mvc;
using MvcAppCollect.Models;
using MvcAppCollect.Data;

namespace MvcAppCollect.Controllers
{
    //[Route("[controller]/[action]")]
    public class ItemController : Controller
    {
        //[HttpGet("{CollectionId}")]
        public IActionResult Index(int id)
        {
            IEnumerable<Item> objCollectionsList = _db.Items;
            return View(objCollectionsList);
           
        }
    }
}
