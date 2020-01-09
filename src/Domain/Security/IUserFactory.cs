namespace Domain.Security
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// User <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity-factory">Entity Factory Domain-Driven Design Pattern</see>.
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// Creates new User.
        /// </summary>
        /// <param name="customer">Customer object.</param>
        /// <param name="externalUserId">ExternalUserId.</param>
        /// <returns>New User instance.</returns>
        IUser NewUser(CustomerId customer, ExternalUserId externalUserId);
    }
}
