﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerkanBilselGorev7.Data;
using System.Security.Claims;

namespace SerkanBilselGorev7.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var kullanici = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.IsActive);
                if (kullanici == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız!";
                }
                else
                {
                    var haklar = new List<Claim>() // claim = hak
                    {
                        new Claim(ClaimTypes.Email, kullanici.Email) // giriş için hak tanımladık
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcıya kimlik tanımladık
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (kullanici.IsAdmin)
                    {
                        return Redirect("/Admin/Default");
                    }
                    else
                    {
                        return Redirect("/Home");
                    }
                }
            }
            catch (Exception)
            {

                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }

        [Route("Logout")] // Adres çubuğundan yaptığımız yönlendirmede login/logout yerine sadece logout'a gidince çıkış yapsın.
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }


    }
}
