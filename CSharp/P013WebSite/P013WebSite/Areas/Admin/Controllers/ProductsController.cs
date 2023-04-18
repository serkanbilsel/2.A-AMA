using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;
using P013WebSite.Entities;
using P013WebSite.Tools;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _databaseContext; // _databaseContext'i boş olarak ekledik. Sağ klik, ampule tıklayıp --> generate consructor diyerek DI(DependencyInjection) işlemini yapıyoruz.

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; // context'i kurucu metotta doldurduk
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            /* return View(_databaseContext.Products.ToList());*/

            // var model oluşturmadan direkt sayfaya modeli bu şekilde de yollayabiliriz.

            return View(_databaseContext.Products.Include(a => a.Category).ToList()); // Products tablosundaki kayıtlara EntityFrameworkCore'un Include metoduyla kategorilerini de dahil ettik böylece ssql deki join işlemi yapılmış oldu.
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
            // Bir nesne olarak gözükmesinden çok Display kısımlarının gözükmesi daha mantıklıdır.
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product collection, IFormFile? Image) // resim geleceğini belirtmek için IFormFile kullandık.
        {
            try
            {
                collection.Image = await FileHelper.FileLoaderAsync(Image); // FileLoaderAsync bizim Tools klasörü içerisine yazdığımız yeni bir metod

                await _databaseContext.Products.AddAsync(collection); // asenkron metotlar çağrılırken mutlaka başına await anahtar kelimesini yazıyoruz!!!!!

                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
            return View(_databaseContext.Products.Find(id));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image);
                    // Metodu üzerine gelip async yapmalıyız! senkron metodun içinde asenkron metod çağrılmaz.

                    // Bir senkron metodun içerisinde asenkron metot çağrılırsa ilgili senkron metot da asenkrona çevrilmelidir. Bu işlem için içerdeki asenkron metodun üzerine gelip ampulün çıkması beklenmeli ve gelen menüden make method async seçeneğine tıklayıp hatanın giderilmesini sağlıyoruz.

                    // Sonuçta ActionResult Ogesi Task<ActionResult> olarak dönüşecektir. Ayrıca başına bir async alacaktır...
                }

                _databaseContext.Products.Update(collection);
                await _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_databaseContext.Products.Include(a => a.Category).FirstOrDefault(p => p.Id == id));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                _databaseContext.Products.Remove(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
