using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC08ViewResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
    
        public IActionResult Yonlendir(string arananDeger)
        {
            //  return Redirect("/Home"); // Bu action tetiklendiğinde uygulama anasayfaya gitsin.


             return Redirect($"/Home?kelime={arananDeger}");  
            //burada ? işaretinden sonraki kısım querystring yöntemiyle adres çubuğu üzerinden veri yollamak için ( taraıyıcı ? işaretinden sonrasını adres olarak almaz

          //  return Redirect("https://getbootstrap.com/");

        }

        public IActionResult ActionaYonlendir()
        {
          //  return RedirectToAction("Index"); // Metot çalıştığında  aynı controllerdaki bir actiona yönlendirmemizi sağlar.

            return RedirectToAction("Index", "Home"); // Metot çalıştığında farklı bir controller daki actiona bu şekilde yönlendirebiliriz.
        }

        public IActionResult RouteYonlendir()
        {

            return RedirectToRoute("Default", new {controller="Home", action="Index", id = 18}); // metot çalıştığında route sistemiyle yönlendirme yapmamızı sağlar
        }



    }
}
