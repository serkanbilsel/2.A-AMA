using Microsoft.AspNetCore.Mvc;
using SerkanBilselGorev7.Models;
using System.Diagnostics;

namespace SerkanBilselGorev7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new List<Slider>()
         {
           
             new Slider() { Name = "Görev 7 - Asp.Net Mvc Kurumsal Site Tasarımı",
                 Description = "Asp .Net Core MVC ile bootstrap kod snippetlarını kullanarak kurumsal site oluşturma.", 
                Image = "/Images/aspnet.jpg", 
                 Link = "google.com" },

                 new Slider() { Name = "Uygulamada Products, Categories, Slider ve User Model Class ları tanımlanacak",
                 Description = "Veritabanında Gorev7ProjeDb isminde bir veritabanı oluşturup içerisine manuel olarak model classlarındaki tablolar ve kolonları oluşturulacak",
                Image = "/Images/c.jpg",
                 },

                  new Slider() { Name = "Projeye Admin isminde bir area eklenip bu area ya bootstrap'ın",
                 Description = "Asp .Net Core MVC ile bootstrap kod snippetlarını kullanarak kurumsal site oluşturma. Projenin ön yüzüne de https://getbootstrap.com/docs/5.3/examples/carousel/ adresindeki şablon uygulanacak\r\nNot: Veritabanı işlemleri yapılmayacak",
                Image = "/Images/vs.jpg",
                 Link = "https://getbootstrap.com/docs/5.3/examples/dashboard/" },








        };
            return View(model);
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Privacy()
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