using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
