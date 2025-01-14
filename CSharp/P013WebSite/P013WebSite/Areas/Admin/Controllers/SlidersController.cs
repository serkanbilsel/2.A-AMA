﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;
using P013WebSite.Entities;
using P013WebSite.Tools;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {


        private readonly DatabaseContext _context; // Sağ tık ampul > constructor Bağlılık Enjeksiyonu, Dependecy Injection denilen olayı kurduk

        // S.O.L.I.D Prensipleri - Clean Code

        public SlidersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: SlidersController
        public async Task<ActionResult> Index()
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

            // async action için metodların başına await yazarak actionresult kısmını da Task<> içine almak gerekir.
        {
            try
            {
                collection.Image = await FileHelper.FileLoaderAsync(Image);

                await _context.AddAsync(collection);
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
            if (id == null)
            {
                return RedirectToAction("Index");
            }
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
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                }
               

                 _context.Update(collection); 

                // Güncellemede ve silmede asenkron metod bulunmamaktadır.

                // EntityFramework üzerinde update ve delete metodları asenkron çalışmıyor add ve listeleme metodları async olarak çalışır.

                await _context.SaveChangesAsync();
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
            if (id == null)
            {
                return RedirectToAction("Index");
            }
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
