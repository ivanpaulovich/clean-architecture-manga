namespace Acerola.Application.Accounts.Withdraw
{
    using System.Threading.Tasks;

    public interface IInputBoundary
    {
        Task Handle(Request request);
    }
}
