using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // BURADA VERÝTABANI ÝÞLEMLERÝ ÝÇÝN KULLANDIÐIMIZ CONTEXTÝ TANITIYORUZZZ
// VERÝTABANI OLUÞTURMAK ÝÇÝN ÜST MENÜDEN TOOLS > NUGET PACKAGE MANAGER > PACKGAE MANAGER CONSOLE MENÜSÜNDEN KOMUT YAZMA EKRANINI AÇIYORUZ.
// BU EKRANA ADD-MÝGRATÝON ýNÝTTÝALcREATE YAZIP ENTER A BASIYORUZ.
// DONE. MESAJI GELDÝYSE ÝÞLEM BAÞARILIDIR.

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
