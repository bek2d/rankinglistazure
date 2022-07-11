using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
