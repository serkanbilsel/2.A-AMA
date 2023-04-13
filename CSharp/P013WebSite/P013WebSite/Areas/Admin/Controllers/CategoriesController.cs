using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P013WebSite.Data;
using P013WebSite.Entities;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: CategoriesController
        public ActionResult Index()
        {
            var model = context.Categories.ToList();
            return View(model);
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
        public ActionResult Create(Category collection)
        {
            try
            {
                context.Categories.Add(collection); // context üzerinde categories tablosuına collectiondaki kategoriyi ekle
                context.SaveChanges(); // yukarıdaki ekleme işlmenini veritabanına işle
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = context.Categories.Find(id); // Model oluşturuo context.categories.find ile parametre olarak id verip view modeli içinde model ile yakalıyoruz.
            // context üzeirnden veritabanındaki kategorilerden idsi route dan gelenle eşleşen kaydı getirir find metodu
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)  // IFROMFILE ları category olarak değiştirdik
        {
            try
            {
                context.Categories.Update(collection);
                context.SaveChanges();  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.Categories.Find(id);
            return View(model);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                context.Categories.Remove(collection); // ekrandan gelen kategoriyi sil
                context.SaveChanges(); // silme işleminbi db ye işlle
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
