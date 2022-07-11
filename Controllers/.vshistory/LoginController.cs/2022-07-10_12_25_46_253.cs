using Microsoft.AspNetCore.Mvc;

namespace MvcAppCollect.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
