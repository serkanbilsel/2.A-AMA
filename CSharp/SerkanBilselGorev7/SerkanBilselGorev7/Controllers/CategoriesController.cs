using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SerkanBilselGorev7.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Data.DatabaseContext _context;

        public CategoriesController(Data.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            if (id is null)  // Eğer AdRES ÇUBUĞUNDAN İD GÖNDERMİLMEMİŞSE
                return BadRequest();   // EKRANA GEÇERSİZ İSTEK HATASI VER 
            var category = _context.Categories.Include(p => p.Products).FirstOrDefault(c => c.Id == id); // İD GÖNDERMİŞSE DB DEN O KATEGORİYİ ARA
            if (category == null)  // EĞER KATEGORİ DB DE YOKSA 
                return NotFound(); // GERİYE BULUNAMADI HATASI DÖNDÜR
            return View(category);
        }
    }
}
