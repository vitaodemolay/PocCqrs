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

            builder.HasKey(f => f.Id)
                .HasName("CustomerId");

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(f => f.Contacts)
                .WithOne()
                .HasForeignKey("CustomerId")
                .OnDelete(DeleteBehavior.Cascade);

            var navigation = builder.Metadata.FindNavigation(nameof(Customer.Contacts));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
