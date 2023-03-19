using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class Blog : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
