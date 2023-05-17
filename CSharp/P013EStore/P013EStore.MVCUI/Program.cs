using P013EStore.Data;
using P013EStore.Service.Abstract;
using P013EStore.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies; // Oturum iþlemleri için bu kütüphaneleri elle ekledik.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>),typeof(Service<>));
builder.Services.AddTransient<IProductService, ProductService>();
// kendi yazdýðýmýz db iþlemlerini yapan servisi .net core da bu þekilde mvc projesine servis olarak tanýttýk

//UYGULAMA ADMÝN PANELÝ ÝÇÝN OTURUM AÇMA AYARLARI
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>// oturum iþlemleri için
{
    x.LoginPath = "/Admin/Login"; // oturum açmayan kullanýcýlarýn giriþ için göndereliceði adres
    x.LogoutPath = "/Admin/Logout";
    x.AccessDeniedPath = "/AccesDenied"; // yetkilendirme ile ekrana eriþim hakký olmayan kullanýcýlarýn gönderileceði sayfa
    x.Cookie.Name = "Administrator"; //  Oluþacak cookie ismi
    x.Cookie.MaxAge = TimeSpan.FromDays(1); // Oluþacak cooki'nin yaþam süresi 1 gün.
});
//Uygulama admin paneli için admin yetkilendirme aarlarý

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", p=>p.RequireClaim("Role", "Admin")); // admin paneline giriþ yapma yetkisine sahip olanlarý bu  kuralla kontrol edeceðiz.
    x.AddPolicy("UserPolicy", p=>p.RequireClaim("Role", "User")); // admin dýþýnda yetkilendirme kullanýýrsak bu kuralý kullanabiliriz(siteye üye giriþi yapanlarý ön yüzde bir paneldepanele eriþtirme gibi)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // DÝkkat! önce UseAuthentication satýrý gelmeli sonra Use Authorization
app.UseAuthorization();

app.MapControllerRoute(
          name: "admin",
          pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
        );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
