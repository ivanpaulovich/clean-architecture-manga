namespace Application.Services
{
    using Domain.ValueObjects;

    public interface IUserService
    {
         ExternalUserId GetExternalUserId();

         Name GetUserName();
    }
}