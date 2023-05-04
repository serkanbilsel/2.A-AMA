using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P013KatmanliBlog.Core.Entities;

namespace P013KatmanliBlog.Data.Configurations
{
    internal class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Logo).HasMaxLength(50);
        }
    }
}
