namespace Domain.Security
{
    using System.Threading.Tasks;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// User <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#repository">Repository Domain-Driven Design Pattern</see>.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets User.
        /// </summary>
        /// <param name="externalUserId">External UserId.</param>
        /// <returns>User.</returns>
        Task<IUser> Get(ExternalUserId externalUserId);

        /// <summary>
        /// Adds the User.
        /// </summary>
        /// <param name="user">User instance.</param>
        /// <returns>Task.</returns>
        Task Add(IUser user);
    }
}
