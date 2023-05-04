using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P013EStore.Core.Entities;

namespace P013EStore.Data.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).HasMaxLength(50);
            builder.Property(x => x.ProductCode).HasMaxLength(50);
            // FluentAPI  ile classlar arası ilişki kurma // 2 CLASS ARALARINDA İLİŞKİ KURMA
            //ÖRNEĞİN ELEKTRONİK KATEGORİSİNDE ZİBİLYONTANE ÜRÜN OLABİLİR, 1 E ÇOK İLİŞKİ AÇIKLAMASI BU 
            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x=>x.BrandId); // Brand clası ile Products classı arasında 1 e çok ilkişki vardır
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(c=>c.CategoryId); // Category classı ile Products classı arasında 1 e çok ilişki vardır
        }
    }
}
