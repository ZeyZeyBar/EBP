using Microsoft.AspNetCore.Mvc;

namespace EBP.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
