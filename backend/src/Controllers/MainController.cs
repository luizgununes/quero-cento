using Microsoft.AspNetCore.Mvc;

namespace queroCentoBE.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}