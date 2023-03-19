var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting(); // uygulama routing ile yölendirmeyi kullansýn
app.UseAuthentication(); // uygulama kullanýcý giriþ sistemini aktif etsin
app.UseAuthorization(); // uygulama kullanýcý yetkilendirme(admin, user vb) sistemini aktif etsin

app.MapControllerRoute( // uygulamanýn kullanacaðý routing yönlendirme ayarý
    name: "default", // route adý 
    pattern: "{controller=Home}/{action=Index}/{id?}"); // eðer adres çubuðunda uygulamaya bir controller adý ve action adý gönderilmezse varsayýlan olarak Home ctonroller 'ý ve içindeki Index isimli action 'ý çalýþtýrsýn. id deðeri ise ? iþareti ile parametrik yani isteðe baðlý belirtilmiþ.

app.Run(); // uygulamayý yukarýdaki ayarlarý kullanarak çalýþtýr.

