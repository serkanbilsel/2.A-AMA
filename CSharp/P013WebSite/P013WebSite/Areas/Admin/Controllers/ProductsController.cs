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
        private readonly DatabaseContext _databaseContext; // _databaseContext i boş olarak ekledik, sağ click ampule basıp "generete constuctor" diyerek DI(dependencyInjection) - Bağımlılık kaldırma işlemini yapıyoruz. .NET CORE DA kullanılan ve tavsiye edilen yöntem bu

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
          //  return View(_databaseContext.Products.ToList()); // Var model oluşturmadan direk sayfaya modeli bu şekilde de yollayabiliyoruz
            return View(_databaseContext.Products.Include(c=>c.Category).ToList()); // ÜRÜN EKLEDİKTEN SONRA KATEGORİSİ GÖSTERMEDİĞİ İÇİN BUNU YAPTIK.
            //PRODUCTS TABLOSUNDAKİ KAYITLARA ENTİTİYFRAMEWORKCORE UN INCLUDE METODUYLA KATEGORİLERİNİ DE DEAHİL ETTİK, BÖYLECE SQLDEKİ JOİN İŞLEMİ YAPILMIŞ OLDU
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name"); // Eğer string olarak id name verilmezse kategori isimleri gelmez.
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product collection, IFormFile? Image) // RESİM YÜKLEMEK İÇİN IFORMFİLE IMAGE PARAMETRESİNİ GÖNDERDİK CREAT E 
        {
            try
            {
                collection.Image = await FileHelper.FileLoaderAsync(Image); // Asekntron metotlar çağırılırken mutlaka başına await anahtar kelimesini yazıyoruz.
                await _databaseContext.Products.AddAsync(collection);
                _databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name"); // Eğer hataya düşersek view.bag tekrar geri dönsün
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
            return View(_databaseContext.Products.Find(id));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.Image = await FileHelper.FileLoaderAsync(Image); // Bir sekontron metodun içerisinde asenkron bir metot çağırılırsa metot async TASK < > arasına alınmalı yani ilgili metot asekntrona çevrilmelidir. Bu işlem için üzerine gelip bekleyip ampule tıklayıp " MAKE ASYNC" E TIKLAYACAĞIZ.
                }
                _databaseContext.Products.Update(collection);
                _databaseContext.SaveChanges();
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
            return View(_databaseContext.Products.Include(c=> c.Category).FirstOrDefault(p=> p.Id == id)); // parantez içindeki sorguya Lambda expration adı
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
