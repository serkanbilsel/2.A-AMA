using Microsoft.AspNetCore.Mvc;
using P013EStore.Core.Entities;
using P013EStore.MVCUI.Models;
using P013EStore.MVCUI.Utils;
using P013EStore.Service.Abstract;
using System.Diagnostics;

namespace P013EStore.MVCUI.Controllers
    // var model = await _post.GetAllAsync();
            //return View(model);
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _serviceSlider;
        private readonly IService<Product> _serviceProduct;
        private readonly IService<Contact> _serviceContact;

        public HomeController(IService<Slider> serviceSlider, IService<Product> serviceProduct, IService<Contact> serviceContact)
        {
            _serviceSlider = serviceSlider;
            _serviceProduct = serviceProduct;
            _serviceContact = serviceContact;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()  //await _serviceSlider.GetAllAsync();
            {
                Sliders = await _serviceSlider.GetAllAsync(),
                Products = await _serviceProduct.GetAllAsync(p=>p.IsActive && p.IsHome)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("iletisim")]
        public IActionResult ContactUs()
        {
            return View();
        }
  

        [Route("iletisim"), HttpPost]
        public async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceContact.AddAsync(contact);
                    var result = await _serviceContact.SaveAsync();
                    if (result > 0)
                    {
                      //  await MailHelper.SendMailAsync(contact); // gelen mesajı mail gönder
                        TempData["Message"] = "<div class='alert alert-success'>Mesajınız Gönderildi! Teşekkkürler... </div>";
                        return RedirectToAction(nameof(ContactUs));
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }
        [Route("AccesDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}