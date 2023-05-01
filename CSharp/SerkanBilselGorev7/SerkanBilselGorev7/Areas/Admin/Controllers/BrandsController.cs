using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerkanBilselGorev7.Data;
using SerkanBilselGorev7.Models;
using SerkanBilselGorev7.Tools;

namespace SerkanBilselGorev7.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class BrandsController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public BrandsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: BrandsController
        public async Task<ActionResult> Index()
        {
            return View(await _dbContext.Brands.ToListAsync());
        }

        // GET: BrandsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Brand collection, IFormFile? Logo)
        {
            try
            {
                if (Logo is not null)
                    collection.Logo = await FileHelper.FileLoaderAsync(Logo);
                await _dbContext.Brands.AddAsync(collection);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandsController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));
            return View(await _dbContext.Brands.FindAsync(id));
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Brand collection, IFormFile? Logo)
        {
            try
            {
                if (Logo is not null)
                    collection.Logo = await FileHelper.FileLoaderAsync(Logo);
                _dbContext.Brands.Update(collection);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandsController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));
            return View(await _dbContext.Brands.FindAsync(id));
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Brand collection)
        {
            try
            {
                _dbContext.Brands.Remove(collection);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
