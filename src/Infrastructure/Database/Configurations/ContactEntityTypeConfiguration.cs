using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Database.Configurations
{
    internal class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("TbContact");

            builder.Property<Guid>("CustomerId")
                .IsRequired();

            builder.Property(f => f.Type)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property(f => f.Value)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasKey("CustomerId", nameof(Contact.Type), nameof(Contact.Value));
        }
    }
}
