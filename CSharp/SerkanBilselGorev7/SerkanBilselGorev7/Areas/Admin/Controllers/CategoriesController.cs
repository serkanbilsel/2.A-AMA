using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerkanBilselGorev7.Data;
using SerkanBilselGorev7.Models;

namespace SerkanBilselGorev7.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Categories collection)
        {
            try
            {
                await _context.Categories.AddAsync(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));
            return View(await _context.Categories.FindAsync(id));
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Categories collection)
        {
            try
            {
                _context.Categories.Update(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Index));
            return View(await _context.Categories.FindAsync(id));
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Categories collection)
        {
            try
            {
                _context.Categories.Remove(collection);
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
