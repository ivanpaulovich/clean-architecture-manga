namespace Application.Services
{
    using Domain.Customers;
    using Domain.Users;

    public interface IUserService
    {
        CustomerId? GetCustomerId();

        ExternalUserId GetExternalUserId();

        Name GetUserName();
    }
}
