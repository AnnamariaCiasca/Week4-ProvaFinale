using Gestore.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestore.EF.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .Property(o => o.OrderCode)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(o => o.OrderDate)
                .IsRequired();

            builder
                .Property(o => o.ProductCode)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(o => o.Amount)
                .IsRequired();
        }
    }
}