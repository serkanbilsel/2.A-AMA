using Microsoft.EntityFrameworkCore;
using P013EStore.Core.Entities;
using P013EStore.Data.Configurations;
using System.Reflection;

namespace P013EStore.Data
{
    public class DatabaseContext : DbContext
    {
        // Katmanlı mimaride bir proje katmanından başka bir katmana erişebilmek için bulunduğumuz data projesinin Dependencies kısmına sağ tıklayıp > Add project references diyerek açılan pencereden Core projesine Tik Atıp ok diyerek pencereyi kapatmamız gerekiyor.

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts   { get; set; }
        public DbSet<Product> Products   { get; set; }
        public DbSet<Slider> Sliders   { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // OnCinfiguring metodu EntitityFrameWorkCore ile gelir ve veritabanı bağlantı ayarlarını yapmamızı sağlar.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=P013EStore; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);

            //CANLI BİR DATABASE BAĞLANTISI YAPMAK İÇİN AŞAĞIDAKİ ADIMLARI UYGULA

           // optionsBuilder.UseSqlServer(@"Server=CanlıServerAdı; Database=CanlıDatabaseAdı;
           // Username=CanlıVeritabanıKullanıcıAdı; Password=CanlıVeritabanıŞifre);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENTAPI VERTABANINDAKİ KOLONLARIN AYARLANMASINI SAĞLAYAN YAPIDIR
            //FLuentAPI ile veritabanı tablolarımız oluşurken veri tiplerini db kurallarını burada tanımlayabiliriz.
            modelBuilder.Entity<AppUser>().Property(a => a.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            //FluentAPİ ile AppUser Classının Name Propertysi için oluşacak veritabanı kolonu ayarlarını bu şekilde belirledik
            modelBuilder.Entity<AppUser>().Property(a => a.Surname).HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.UserName).HasColumnType("varchar(50)").HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Password).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            modelBuilder.Entity<AppUser>().Property(a => a.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AppUser>().Property(a => a.Phone).HasMaxLength(20);

            //FLUENTAPI HasData ile db oluştuktan sonra başlangıç kayıtları ekleme
            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = 1,
                Email = "info@P013EStore.com",
                Password = "123",
                UserName = "Admin",
                IsActive = true,
                IsAdmin = true,
                Name = "Admin",
                UserGuid = Guid.NewGuid(),// Kullanıcıya benzersiz bir id no oluşturuyoruz.
            });



            //modelBuilder.ApplyConfiguration(new BrandConfigurations()); // Marka için yaptığımız konfigürasyon ayarlarını çağırdık
            //modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            //modelBuilder.ApplyConfiguration(new ContactConfigurations());
            //modelBuilder.ApplyConfiguration(new ProductConfigurations());
            //modelBuilder.ApplyConfiguration(new SliderConfigurations());


            // DATABASE İÇİN ÖZELLİKLERİNİ CLASS AÇARAK VERDİĞİMİZ BU PROPORTYLERİ KISA YOLDAN EKLEMEK İÇİN AŞAĞIDAKİ YÖNTEMİ DENE

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // uygulamadıki tüm configurations classlarını burada çalıştır


            // Fluent Validation :  Data annotationdaki hata mesajları vb işlemleri yönetebileceğimiz 3.Parti paket.





            // P013EStore.MVCUI ana uygulamadaki database e erişemedik. Bu yüzden katmanlı mimraride ;
            //MVCWEBUI katmanından direk data katmanına erişlmesi istenmez, arada bir iş katmanının
            //tüm db süreçlerini yönetiyor olması beklenir. Bu yüzden solutiona service katmanı ekleyip
            //Mvc. katmanından service katmanına erişim vermemiz gerekiyor.. 
            // İŞ KATMANLARINDA MUTLAKA SERVİCE KATMANI OLUŞTURULUR VE KATMANLAR ARASI BAĞLILIĞI AZALTMAK AMAÇTIR.
            // Service katmanı da data katmanına erişir. Data katmanı da core katmanına erişir, böylece MVCUI > service > data > Core
            // ile en üstten en alt katmana kadar ulaşabilmiş olunur. 

            base.OnModelCreating(modelBuilder);



        }
    }
}