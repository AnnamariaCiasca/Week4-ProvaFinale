using Gestore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestore.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CustomerCode)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
