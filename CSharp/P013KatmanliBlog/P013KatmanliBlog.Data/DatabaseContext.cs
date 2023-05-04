using Microsoft.EntityFrameworkCore;
using System.Reflection;
using P013KatmanliBlog.Core.Entities;


namespace P013KatmanliBlog.Core.Entities
{
    public class DatabaseContext : DbContext

    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=P013KatmanliBlog; Trusted_Connection=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = 1,
                Email = "info@P013KatmanliBlog.com",
                Password = "123",
                UserName = "Admin",
                IsActive = true,
                IsAdmin = true,
                Name = "Admin",
                UserGuid = Guid.NewGuid(),

            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
