using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerkanBilselGorev7.Data;
using SerkanBilselGorev7.Models;
using SerkanBilselGorev7.Tools;

namespace SerkanBilselGorev7.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public ProductsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            return View(await _dbContext.Products.Include(x => x.Category).ToListAsync());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _dbContext.Categories.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Products collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                await _dbContext.Products.AddAsync(collection);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(await _dbContext.Categories.ToListAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));
            ViewBag.CategoryId = new SelectList(await _dbContext.Categories.ToListAsync(), "Id", "Name");
            return View(await _dbContext.Products.FindAsync(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Products collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                    collection.Image = await FileHelper.FileLoaderAsync(Image);

                _dbContext.Products.Update(collection);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(await _dbContext.Categories.ToListAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));
            return View(await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(q => q.Id == id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Products collection)
        {
            try
            {
                _dbContext.Products.Remove(collection);
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
