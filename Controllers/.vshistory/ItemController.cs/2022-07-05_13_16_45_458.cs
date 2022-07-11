using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
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
