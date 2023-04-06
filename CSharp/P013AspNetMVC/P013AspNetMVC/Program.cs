using P013AspNetMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UyeContext>(); // bu satýrý sanal veritabaný kullanabilmek için ekledik

builder.Services.AddSession(); // uygulama session kullanabilmek için bu satýrý ekliyoruz

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Uygulama http isteklerini https ile güvenli baðlantýya yönlendirmeyi desteklesin
app.UseStaticFiles(); // uygulama statik dosyalarI(wwwroot klasöründekiler) desteklesin
app.UseSession(); //   // uygulama session kullanabilmek için bu satýrý ekliyoruz


app.UseRouting(); // uygulama routing ile yölendirmeyi kullansýn
app.UseAuthentication(); // uygulama kullanýcý giriþ sistemini aktif etsin
app.UseAuthorization(); // uygulama kullanýcý yetkilendirme(admin, user vb) sistemini aktif etsin

app.MapControllerRoute(    // AREA EKLEDÝKTEN SONRA SCAFFOLDÝNGREADME.TXT DEN ALDIÐIMIZ KODLARI BURAYA YAPIÞTIRDIK ÇÜNKÜ AREA NIN ÇALIÞMASI ÝÇÝN BU ROUTE U EKLEMEMÝZ GEREKÝYOR
            name: "admin",    // AREAS OLAN YERÝ ADMÝN OLARAK DEÐÝÞTÝRDÝK.
            pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"    //  DEFAULT OLAN KISIM "HOME" DI BÝZ ÝSMÝ DEFAULT VERDÝÐÝMÝZ ÝÇÝN DEFAULT YAPTIK
          );



app.MapControllerRoute( // uygulamanýn kullanacaðý routing yönlendirme ayarý
    name: "default", // route adý 
    pattern: "{controller=Home}/{action=Index}/{id?}"); // eðer adres çubuðunda uygulamaya bir controller adý ve action adý gönderilmezse varsayýlan olarak Home ctonroller 'ý ve içindeki Index isimli action 'ý çalýþtýrsýn. id deðeri ise ? iþareti ile parametrik yani isteðe baðlý belirtilmiþ.

app.Run(); // uygulamayý yukarýdaki ayarlarý kullanarak çalýþtýr.

