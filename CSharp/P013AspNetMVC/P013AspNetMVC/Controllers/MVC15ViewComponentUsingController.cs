using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC15ViewComponentUsingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
