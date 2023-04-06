using P013AspNetMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UyeContext>(); // bu sat�r� sanal veritaban� kullanabilmek i�in ekledik

builder.Services.AddSession(); // uygulama session kullanabilmek i�in bu sat�r� ekliyoruz

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Uygulama http isteklerini https ile g�venli ba�lant�ya y�nlendirmeyi desteklesin
app.UseStaticFiles(); // uygulama statik dosyalarI(wwwroot klas�r�ndekiler) desteklesin
app.UseSession(); //   // uygulama session kullanabilmek i�in bu sat�r� ekliyoruz


app.UseRouting(); // uygulama routing ile y�lendirmeyi kullans�n
app.UseAuthentication(); // uygulama kullan�c� giri� sistemini aktif etsin
app.UseAuthorization(); // uygulama kullan�c� yetkilendirme(admin, user vb) sistemini aktif etsin

app.MapControllerRoute(    // AREA EKLED�KTEN SONRA SCAFFOLD�NGREADME.TXT DEN ALDI�IMIZ KODLARI BURAYA YAPI�TIRDIK ��NK� AREA NIN �ALI�MASI ���N BU ROUTE U EKLEMEM�Z GEREK�YOR
            name: "admin",    // AREAS OLAN YER� ADM�N OLARAK DE���T�RD�K.
            pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"    //  DEFAULT OLAN KISIM "HOME" DI B�Z �SM� DEFAULT VERD���M�Z ���N DEFAULT YAPTIK
          );



app.MapControllerRoute( // uygulaman�n kullanaca�� routing y�nlendirme ayar�
    name: "default", // route ad� 
    pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er adres �ubu�unda uygulamaya bir controller ad� ve action ad� g�nderilmezse varsay�lan olarak Home ctonroller '� ve i�indeki Index isimli action '� �al��t�rs�n. id de�eri ise ? i�areti ile parametrik yani iste�e ba�l� belirtilmi�.

app.Run(); // uygulamay� yukar�daki ayarlar� kullanarak �al��t�r.

