using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P013KatmanliBlog.Core.Entities;

namespace P013KatmanliBlog.Data.Configurations
{
    internal class SliderConfigurations : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.Image).HasMaxLength(50);
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.Link).HasMaxLength(100);
        }
    }
}
