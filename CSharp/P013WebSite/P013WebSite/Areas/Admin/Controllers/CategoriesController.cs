using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P013WebSite.Data;
using P013WebSite.Entities;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
       

        // Bu controller'ı Read/Write actions olarak ekledik.
    {
        DatabaseContext context = new();

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
                // Contet üzerindeki IFormCategories tablosuna collectiondaki kategoriyi ekle.
                // Veriyi veritabanındaki satırlara ekle
                // Create kısmında Savechanges(); demeyi unutmayın.
                context.Categories.Add(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id== null)
            {
                return RedirectToAction("Index");
            }
            var model = context.Categories.Find(id); // context üzerinden veritabanındaki Kategorilerden id'si route'dan gelenle eşleşen kaydı getirir. "Find" metodu
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
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
                context.Categories.Remove(collection); // Ekrandan gelen kategoriyi sil
                context.SaveChanges(); // Silme işlemini db ye işle.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
