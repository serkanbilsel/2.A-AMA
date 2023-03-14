using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        public IActionResult Index(string Ara) // Get Metoduyla gönderilen verileri bu şekilde string Ara yazarak yakalayabiliriz.
        {
            // Mvc de temel olarak 3 farklı yöntemle ekrana veri gönderebiliriz

            // 1- ViewBag :  Tek Kullanımlık ömrü var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2-ViewData :  Tek kullanımlık ömrü var
            ViewData["UrunAdi"] = "Asus Dizüstü Bilgisayar";
            // 3-TempData :  İki Kullanımlık ömrü var
            TempData["UrunFiyati"] = 9999;

            ViewBag.GetVerisi = Ara;
            return View();
        }
        [HttpPost] // Aşağıdaki metot post işleminde çalışsın
        public IActionResult Index(string text1, string ddlListe, string cbOnay)
        {
            // 1- ViewBag
            ViewBag.BirinciYontem = "1. Yöntemle(Parametrelerden gelen veriler)";
            ViewBag.Mesaj = "Textbox dan gelen veri : " + text1;
            ViewBag.MesajListe = "ddlListe dan gelen veri : " + ddlListe;
            TempData["Tdata"] = "cbOnay dan gelen değer : " + cbOnay;
            return View();
        }
    } 
}
