using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu controller'ın admin areasında çalışmasını sağladık.   

    
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
