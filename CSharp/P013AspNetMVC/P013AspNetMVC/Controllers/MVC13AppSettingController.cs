using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;
       

        // Dependency injection ile constructor da oluşturmak için configuration a sağ tık, açılan menüden ampul simgesine tıklayıp açılan menüden generate constructor diyerek oluşturabiliriz.

        public MVC13AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"];
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["Username"] = _configuration["Username"]; 
            TempData["MailKullanici"] = _configuration["MailKullanici:Username"]; // Json daki Mail Kullanici altındaki Username değerine : ile ulaşıyoruz
            TempData["Sifre"] = _configuration.GetSection("MailKullanici:Password").Value;
        
            return View();
        }
    }
}
