using Microsoft.AspNetCore.Mvc;
using P013AspNetMVC.Filters;

namespace P013AspNetMVC.Controllers
{
    public class MVC14FilterUsingController : Controller
    {
        [UserControl] // kendi yazdığımız UserControl attribute'ü ile bu action a oturum açmayan kullanıcıların erişimini engelliyoruz.
        public IActionResult Index()
        {
            ViewBag.Kullanici = HttpContext.Session.GetString("UserGuid"); // UserGuid isimli session daki değeri yakala ve ViewBag.Kullanici ile ekrana gönder
            return View();
        }
    }
}
