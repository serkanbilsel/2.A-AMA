using Microsoft.AspNetCore.Mvc;

namespace ContactUs.Controllers
{
    public class ContactUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
