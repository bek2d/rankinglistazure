using Microsoft.AspNetCore.Mvc;

[Route("Item/Index")]
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
