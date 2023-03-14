using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC02HtmlAndTagHelpers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
