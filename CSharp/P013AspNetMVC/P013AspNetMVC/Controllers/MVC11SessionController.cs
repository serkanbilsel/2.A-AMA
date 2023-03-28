using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC11SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SessionOku()
        {
            HttpContext.Session.Remove("Kullanici");
            return View();
        }
        [HttpPost]
        public IActionResult SessionSil()
        {
            //HttpContext.Session.Remove("Kullanici"); // Lullanıcı isimli session ı sil
            HttpContext.Session.Clear(); // Tüm sessionları sil
            return RedirectToAction("SessionOku"); 
        }

        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "Admin" && sifre == "123")
            {

                HttpContext.Session.SetString("Kullanici", kullaniciAdi); //  session da verileri key-value şeklinde saklıyoruz
                HttpContext.Session.SetString("Sifre", sifre);
                HttpContext.Session.SetInt32("IsLoggedIn", 1); // session da string dışında int tipinde de veri saklayabiliriz.
                HttpContext.Session.SetString("UserGuid", Guid.NewGuid().ToString());
                return RedirectToAction("SessionOku");
            }
            return View();
        }





    }

}
