using EF_Core_Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Configurations
{
    internal class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey("ID");

            builder.Property("Name")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.HasIndex("Name")
                   .IsUnique();
        }
    }
}
