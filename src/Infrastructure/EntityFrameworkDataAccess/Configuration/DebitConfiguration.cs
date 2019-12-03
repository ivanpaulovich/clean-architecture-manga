using Domain.Accounts.Debits;
using Domain.Accounts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkDataAccess.Configuration
{
    public class DebitConfiguration : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.ToTable("Debit");

            builder.Property(debit => debit.Amount)
                .HasConversion(
                    value => value.ToMoney().ToDecimal(),
                    value => new PositiveMoney(value))
                .IsRequired();

            builder.Property(debit => debit.Id)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new DebitId(value))
                .IsRequired();

            builder.Property(debit => debit.AccountId)
                .HasConversion(
                    value => value.ToGuid(),
                    value => new AccountId(value))
                .IsRequired();
            }
    }
}
