using Microsoft.EntityFrameworkCore;
using SerkanBilselGorev7.Models;
using System.Drawing.Drawing2D;

namespace SerkanBilselGorev7.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=SerkanBilselGorev7; trusted_connection=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Serkan",
                    LastName = "Bilsel",
                    Password = "12345",
                    Email = "Serkanbilsel@gmail.com",
                    IsActive = true,
                    IsAdmin = true

                }
            ); ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
