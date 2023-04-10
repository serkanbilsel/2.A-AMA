using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // BURADA VER�TABANI ��LEMLER� ���N KULLANDI�IMIZ CONTEXT� TANITIYORUZZZ
// VER�TABANI OLU�TURMAK ���N �ST MEN�DEN TOOLS > NUGET PACKAGE MANAGER > PACKGAE MANAGER CONSOLE MEN�S�NDEN KOMUT YAZMA EKRANINI A�IYORUZ.
// BU EKRANA ADD-M�GRAT�ON �N�TT�ALcREATE YAZIP ENTER A BASIYORUZ.
// DONE. MESAJI GELD�YSE ��LEM BA�ARILIDIR.

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
