using Microsoft.AspNetCore.Mvc;

namespace P013AspNetMVC.Controllers
{
    public class MVC09FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    

    [HttpPost]

    public IActionResult Index(IFormFile? Image) //Ön yüzdeki file elementinin ismini burdaki IFormFile parametresine veriyoruz !
            // IFormFile? a ? koymamızın sebebi post yapılırken kullanıcı resim yüklemeyebilir, sadece inputlardan veri göndermek isteyebilir. O yüzden ? işareti ile resim dışında birşey yüklemesini engellemek için ? kullanılır.
    {
        if (Image is not null)
        {
            string directory = Directory.GetCurrentDirectory() + "/wwwroot/Images/" + Image.FileName; // dosyanın yükleneceği dizini belirledik
            using var stream = new FileStream(directory, FileMode.Create); // seçilen dosyayı pc den sunucuya gönderecek bir akış oluşturduk
            Image.CopyTo(stream); // akışı kullanarak resmi sunucuya kopyaladık
           
            TempData["Resim"] = Image.FileName;
        }

        return View();
    }

    }
}

