namespace Application.Services
{
    using Domain.ValueObjects;

    public interface IUserService
    {
        CustomerId? GetCustomerId();

        ExternalUserId GetExternalUserId();

        Name GetUserName();
    }
}