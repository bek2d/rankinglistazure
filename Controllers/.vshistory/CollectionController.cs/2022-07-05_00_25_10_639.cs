using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
