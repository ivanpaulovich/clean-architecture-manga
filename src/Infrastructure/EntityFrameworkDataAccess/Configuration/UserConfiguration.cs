namespace Infrastructure.EntityFrameworkDataAccess.Configuration
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(b => b.ExternalUserId)
                .HasConversion(
                    v => v.ToString(),
                    v => new ExternalUserId(v))
                .IsRequired();

            builder.Property(b => b.CustomerId)
                .HasConversion(
                    v => v.ToGuid(),
                    v => new CustomerId(v))
                .IsRequired();

            builder.HasKey(
                c => new { c.ExternalUserId, c.CustomerId }
            );
        }
    }
}
