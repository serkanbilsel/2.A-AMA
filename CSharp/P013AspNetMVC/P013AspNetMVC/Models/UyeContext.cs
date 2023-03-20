using Microsoft.EntityFrameworkCore;

namespace P013AspNetMVC.Models
{
    // InMemoryDb kullanabilmek için projeye sağ tık nuget package manager menüsünü aç ve Microsoft Desing paketini kur.
    // ORadan EtntityFrameworkCore.Inmemory paketini ve EntityFrameworkCore.Desing paketlerini yüklüyoruz
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // EntityFrameworkCore veritabanı işlemleri için yapılandırma ayarlarını yapabildiğimiz bir metot

            optionsBuilder.UseInMemoryDatabase("InMemoryDb"); // bilgisayarımızın ram belliğini sanal veritabanı olarak kullanmasını sağlayan ayarı yaptık.
            // bu ayardan sonra projemizin program.cs classına gidip bu UyeContext sınıfını servis olarak ekleiyoruz.

            base.OnConfiguring(optionsBuilder);
        }
    }

}
