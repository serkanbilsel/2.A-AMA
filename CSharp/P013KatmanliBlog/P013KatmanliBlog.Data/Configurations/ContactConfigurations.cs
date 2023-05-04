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
    internal class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Surname).HasMaxLength(50);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Phone).HasMaxLength(20);
            builder.Property(s => s.Message).HasMaxLength(500);
        }
    }
}
