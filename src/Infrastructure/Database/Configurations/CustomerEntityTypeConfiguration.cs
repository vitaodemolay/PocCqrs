using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("TbCustomer");

            builder.Property(f => f.Id)
               .HasColumnName("CustomerId");

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasKey(f => f.Id);

            builder.HasMany(f => f.Contacts)
                .WithOne()
                .HasForeignKey("CustomerId")
                .OnDelete(DeleteBehavior.Cascade);

            var navigation = builder.Metadata.FindNavigation(nameof(Customer.Contacts));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);


            builder.Property(f => f.CreationDate)
                .HasDefaultValueSql("GetDate()")
                .IsRequired();

            builder.Property(f => f.LastUpdate)
                .IsRequired(false);

            builder.Property(f => f.LastOrder)
                .IsRequired(false);
        }
    }
}
