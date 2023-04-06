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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(    // AREA EKLED�KTEN SONRA SCAFFOLD�NGREADME.TXT DEN ALDI�IMIZ KODLARI BURAYA YAPI�TIRDIK ��NK� AREA NIN �ALI�MASI ���N BU ROUTE U EKLEMEM�Z GEREK�YOR
            name: "Admin",
            pattern: "{area:exists}/{controller=DefaultController}/{action=Index}/{id?}"    //  DEFAULT OLAN KISIM "HOME" DI B�Z �SM� DEFAULT VERD���M�Z ���N DEFAULT YAPTIK
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
