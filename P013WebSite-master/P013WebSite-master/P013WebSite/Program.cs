using P013WebSite.Data;
using Microsoft.AspNetCore.Authentication.Cookies;// ADmin panelde outurujm iþlemi için Authentication ekledik.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // burada veritabaný iþlemleri için kullandýðýmýz contexti tanýtýyoruz
// veritabaný oluþturmak için üst menüden Tools > Nuget Package Manager > Package manger console menüsünden komut yazma ekranýný açýyoruz.
// Bu ekrana add-migration InitialCreate yazýp enter a basýyoruz.
// Migrations klasörü ve initialcreate classý oluþtuktan sonra update-database yazýp enter a basýyoruz
// Done mesajý geldiyse iþlem baþarýlýdýr.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // Login sisteminin varsayýlan login giriþ adresini kendi adresimizle deðiþtiriyoýruz

    x.Cookie.Name = "AdminLogin"; // oturum için oluþacak coockie nin ismini belirledik

} );

// ADMÝN PANELDE AUTHORÝZE ATTRÝBÜTE Ü ÝLE GÜVENLÝK SAÐLADIK.
// DAHA SONRA YUKARI  using Microsoft.AspNetCore.Authentication.Cookies; EKLEDÝK VE  AddAuthentication PARANTEZ ÝÇÝNE YAZILANLARI EKLEYÝP NOKTADAN SONRA ADDCOOKÝE DEDÝK
// DAHA SONRA ADDCOOKÝE NÝN ÝÇÝNE " X => X.LOGÝNPATH = /ADMÝN/LOGÝN EKLEDÝK

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
