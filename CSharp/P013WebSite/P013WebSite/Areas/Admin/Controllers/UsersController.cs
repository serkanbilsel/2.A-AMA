using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P013WebSite.Data;
using P013WebSite.Entities;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly DatabaseContext _context;

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var model = _context.Users.ToList();
            return View(model);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(User collection, IFormFile? Form)
        {
            try
            {
                if (User is not null)

                await _context.Users.AddAsync(collection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
            return View(_context.Users.Find(id));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, User collection, IFormFile? Form)
        {
            try
            {
                _context.Users.Update(collection);
               await  _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
               
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Users = new SelectList(_context.Users.ToList(), "Id", "Name");
            return View(_context.Users.Find(id));
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User collection)
        {
            try
            {
                _context.Users.Remove(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
