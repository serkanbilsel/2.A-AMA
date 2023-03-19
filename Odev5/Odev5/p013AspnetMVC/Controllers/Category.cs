using Microsoft.AspNetCore.Mvc;

namespace Category.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
