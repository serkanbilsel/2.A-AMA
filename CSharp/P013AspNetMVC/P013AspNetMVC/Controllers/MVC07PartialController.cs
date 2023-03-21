using Microsoft.AspNetCore.Mvc;
using P013AspNetMVC.Models;

namespace P013AspNetMVC.Controllers
{
    public class MVC07Partial : Controller
    {
        public IActionResult Index()
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Ad = "Murat";
            kullanici.Soyad = "Malkoç";
            return View(kullanici);
        }
    }
}
