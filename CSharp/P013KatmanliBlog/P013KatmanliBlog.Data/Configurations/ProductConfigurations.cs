using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P013KatmanliBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P013KatmanliBlog.Data.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Image).HasMaxLength(50);
            builder.Property(s => s.ProductCode).HasMaxLength(50);

            builder.HasOne(s => s.Brand).WithMany(s => s.Products).HasForeignKey(s => s.BrandId);
            builder.HasOne(s => s.Category).WithMany(s => s.Products).HasForeignKey(s => s.CategoryId);

        }
    }
}
