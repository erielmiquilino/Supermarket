using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Data.MappingConfiguration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
