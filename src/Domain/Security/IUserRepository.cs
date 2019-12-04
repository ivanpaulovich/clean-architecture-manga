namespace Domain.Security
{
    using System.Threading.Tasks;
    using Domain.Security.ValueObjects;

    public interface IUserRepository
    {
        Task<IUser> Get(ExternalUserId externalUserId);

        Task Add(IUser user);
    }
}
