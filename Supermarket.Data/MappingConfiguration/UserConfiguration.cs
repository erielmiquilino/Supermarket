﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Data.MappingConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Password)
                .IsRequired();
        }
    }
}
