using Domain.Accounts.Credits;
using Domain.Accounts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkDataAccess.Configuration
{
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.ToTable("Credit");

            builder.Property(credit => credit.Amount)
                .HasConversion(
                    value => value.ToMoney().ToDecimal(),
                    value => new PositiveMoney(value))
                .IsRequired();

            builder.Property(credit => credit.Id)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new CreditId(value))
                .IsRequired();

            builder.Property(credit => credit.AccountId)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new AccountId(value))
                .IsRequired();
        }
    }
}
