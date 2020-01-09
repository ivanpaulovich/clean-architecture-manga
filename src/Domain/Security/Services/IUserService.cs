namespace Domain.Security.Services
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// User Service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get Customer Id.
        /// </summary>
        /// <returns>CustomerId.</returns>
        CustomerId? GetCustomerId();

        /// <summary>
        /// Get External User Id.
        /// </summary>
        /// <returns>External User Id.</returns>
        ExternalUserId GetExternalUserId();

        /// <summary>
        /// Get User Name.
        /// </summary>
        /// <returns>User Name.</returns>
        Name GetUserName();
    }
}
