using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;
using P013WebSite.Entities;
using P013WebSite.Tools;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly DatabaseContext _context;
        // GET: SlidersController
        public SlidersController (DatabaseContext context) // S.O.L.I.D Prensipleri - Clean Code ARAŞTIR
        {
            _context = context; 
        }

     

        public async Task<ActionResult> Index(int id)
        {
            var model = await _context.Sliders.ToListAsync();
            return View(model);
        }

        // GET: SlidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SlidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slider collection, IFormFile? Image)
        {
            try
            {
                collection.Image = await FileHelper.FileLoaderAsync(Image);
                await _context.Sliders.AddAsync(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlidersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _context.Sliders.FindAsync(id);
            return View(model);
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Slider collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)

                collection.Image = await FileHelper.FileLoaderAsync(Image);
                      _context.Sliders.Update(collection);  // SİLME VE GÜNCELLEME KODLARINDA ASENKRON ÖZELLİĞİNE GEREK YOK
                await _context.SaveChangesAsync();  // ENTİTY FRAME WORK DE UPDATE VE DELETE METOTLARI ASEKNRON ÇALIŞMIYOR ADD VE LİSTELEME METOTLARI ASYNC
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlidersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _context.Sliders.FindAsync(id);
            return View(model);
           
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Slider collection)
        {
            try
            {
                _context.Sliders.Remove(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
