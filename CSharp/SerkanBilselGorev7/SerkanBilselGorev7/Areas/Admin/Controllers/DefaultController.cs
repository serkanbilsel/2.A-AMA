using Microsoft.AspNetCore.Mvc;

namespace SerkanBilselGorev7.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
