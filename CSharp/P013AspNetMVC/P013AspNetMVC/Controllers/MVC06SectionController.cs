using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC06SectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
