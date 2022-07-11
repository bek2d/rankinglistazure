using Microsoft.AspNetCore.Mvc;


namespace MvcAppCollect.Controllers
{
    //[Route("[controller]/[action]")]
    public class ItemController : Controller
    {
        //[HttpGet("{CollectionId}")]
        public IActionResult Index(int id)
        {
            //IEnumerable<Item> objCollectionsList = _db.Collections;
            //return View(objCollectionsList);
            return View();
        }
    }
}
