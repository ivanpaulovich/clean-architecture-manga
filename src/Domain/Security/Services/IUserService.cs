namespace Domain.Security.Services
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public interface IUserService
    {
        CustomerId? GetCustomerId();

        ExternalUserId GetExternalUserId();

        Name GetUserName();
    }
}
