using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // Burada veritabaný iþlemleri için kullandýðýmýz contexti tanýtýyoruz.

// veritabaný oluþturmak için üst menüden Tools> Nuget Package Manager > Package Manager Console menüsünden komut yazmak için console ekranýný açýyoruz.

// Bu ekrana add-migration InitialCreate yazýp enter a basýyoruz.

// Migrations klasörü ve initialcreate classý oluþtuktan sonra update-database yazýp enter'a basýyoruz.

// Done mesajý geldiyse iþlem baþarýlýdýr.



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

//endpoints.MapControllerRoute(
//name: "areas",
//            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//          );

// Yukarýdaki þekildeyken biz endpoints yerine app yazdýk

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
