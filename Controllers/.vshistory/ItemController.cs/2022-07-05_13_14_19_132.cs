using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Controllers
{
    public class ItemController : Controller
    {
    //    [HttpGet("{id}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
