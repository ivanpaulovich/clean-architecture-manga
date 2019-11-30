namespace Application.Repositories
{
    using System.Threading.Tasks;
    using Domain.Users;

    public interface IUserRepository
    {
        Task<IUser> Get(ExternalUserId externalUserId);

        Task Add(IUser user);
    }
}
