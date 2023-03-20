using Microsoft.AspNetCore.Mvc;
using P013AspNetMVC.Models;

namespace P013AspNetMVC.Controllers
{

    public class MVC05ModelValidationController : Controller
    {
        UyeContext context = new UyeContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UyeListesi()
        {
            var model = context.Uyes.ToList(); // context içinde yer alan Uyes tablasoundaki verileri listele ve model isimli değişkleni aktar
            return View(model); // view sayfasına model bu şekilde gönderiliyor
        }

        public IActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniUye(Uye uye)
        {

            if (ModelState.IsValid) // Eğer parantez içersinde gönderilen üye nesnesi validasyon kurallarına uygun uygunsa
            {
                // bu bloktaki kodları çalıştır Mesela gönderilen üye nesnesini veritabanına ekle
                context.Uyes.Add(uye); // View dan gönderilen  üye nesnesini context üzerindeki  uyes tablosuna ekle
                context.SaveChanges(); // üst satırdaki ekleme işlemini kaydet
                return RedirectToAction("UyeListesi");

            }

            else
            {
                ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz!");
            }
            return View();

            
        }


    }
}
