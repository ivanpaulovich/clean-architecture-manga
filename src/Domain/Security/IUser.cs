namespace Domain.Security
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// User <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#aggregate-root">Aggregate Root Domain-Driven Design Pattern</see>.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets the External UserId.
        /// </summary>
        ExternalUserId ExternalUserId { get; }

        /// <summary>
        /// Gets the CustomerId.
        /// </summary>
        CustomerId CustomerId { get; }
    }
}
