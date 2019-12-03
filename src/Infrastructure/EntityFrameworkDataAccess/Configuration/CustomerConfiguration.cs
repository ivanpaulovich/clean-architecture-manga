namespace Infrastructure.EntityFrameworkDataAccess.Configuration
{
    using Domain.Customers.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder
            <Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(b => b.SSN)
                .HasConversion(
                    v => v.ToString(),
                    v => new SSN(v))
                .IsRequired();

            builder.Property(b => b.Name)
                .HasConversion(
                    v => v.ToString(),
                    v => new Name(v))
                .IsRequired();

            builder.Property(b => b.Id)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CustomerId(v))
                .IsRequired();

            builder.Ignore(p => p.Accounts);
        }
    }
}
