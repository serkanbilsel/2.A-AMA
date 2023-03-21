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
            var kayit = context.Uyes.Find(); // adres çubuğundaki route üzeirnden gönderilen id ile eşleşen kaydı bul
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


        public IActionResult UyeDuzenle(int id)
        {
            var kayit = context.Uyes.Find(id); // adres çubuğundaki route üzeirnden gönderilen id ile eşleşen kaydı bul
            return View(kayit);
           
        }
        [HttpPost]
        public IActionResult UyeDuzenle(Uye uye)
        {

            if (ModelState.IsValid) // Eğer parantez içersinde gönderilen üye nesnesi validasyon kurallarına uygun uygunsa
            {
                // bu bloktaki kodları çalıştır Mesela gönderilen üye nesnesini veritabanına ekle
                context.Uyes.Update(uye); // View dan gönderilen  üye nesnesini günceller
                context.SaveChanges(); // üst satırdaki güncelleme işlemini kaydet
                return RedirectToAction("UyeListesi");

            }

            else
            {
                ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz!");
            }
            return View();

        }

    

        public IActionResult UyeSil(int id)
        {
            var kayit = context.Uyes.Find(id); // adres çubuğundaki route üzerinden gönderilen id ile esleşen kaydı bul 
            return View(kayit);
        }
        [HttpPost]
        public IActionResult UyeSil(Uye uye)
        {
            try
            {
                context.Uyes.Remove(uye);// View dan gönderilen uye nesnesini sil
                context.SaveChanges(); // üst satırdaki sil işlemini kaydet.
                return RedirectToAction("UyeListesi");
            }
            catch (Exception hata)
            {
                ModelState.AddModelError("", "Hata Oluştu !" + hata.Message);
            }
            return View();
        }
           
          
    }
}
