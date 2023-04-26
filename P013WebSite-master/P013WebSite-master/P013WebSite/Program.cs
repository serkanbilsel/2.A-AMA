using P013WebSite.Data;
using Microsoft.AspNetCore.Authentication.Cookies;// ADmin panelde outurujm i�lemi i�in Authentication ekledik.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // burada veritaban� i�lemleri i�in kulland���m�z contexti tan�t�yoruz
// veritaban� olu�turmak i�in �st men�den Tools > Nuget Package Manager > Package manger console men�s�nden komut yazma ekran�n� a��yoruz.
// Bu ekrana add-migration InitialCreate yaz�p enter a bas�yoruz.
// Migrations klas�r� ve initialcreate class� olu�tuktan sonra update-database yaz�p enter a bas�yoruz
// Done mesaj� geldiyse i�lem ba�ar�l�d�r.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login"; // Login sisteminin varsay�lan login giri� adresini kendi adresimizle de�i�tiriyo�ruz

    x.Cookie.Name = "AdminLogin"; // oturum i�in olu�acak coockie nin ismini belirledik

} );

// ADM�N PANELDE AUTHOR�ZE ATTR�B�TE � �LE G�VENL�K SA�LADIK.
// DAHA SONRA YUKARI  using Microsoft.AspNetCore.Authentication.Cookies; EKLED�K VE  AddAuthentication PARANTEZ ���NE YAZILANLARI EKLEY�P NOKTADAN SONRA ADDCOOK�E DED�K
// DAHA SONRA ADDCOOK�E N�N ���NE " X => X.LOG�NPATH = /ADM�N/LOG�N EKLED�K

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
