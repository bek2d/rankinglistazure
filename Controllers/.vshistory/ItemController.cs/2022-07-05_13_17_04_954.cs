using Microsoft.AspNetCore.Mvc;


namespace MvcAppCollect.Controllers
{
    [Route("[controller]/[action]")]
    public class ItemController : Controller
    {
    //    [HttpGet("{id}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
