namespace Infrastructure.EntityFrameworkDataAccess.Configuration
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.Property(b => b.Id)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new AccountId(v))
                .IsRequired();

            builder.Property(b => b.CustomerId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CustomerId(v))
                .IsRequired();

            builder.Ignore(p => p.Credits)
                .Ignore(p => p.Debits);
        }
    }
}
