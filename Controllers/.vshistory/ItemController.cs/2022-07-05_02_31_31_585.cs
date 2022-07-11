using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
