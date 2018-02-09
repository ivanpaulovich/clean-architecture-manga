namespace Acerola.Application.Accounts.Deposit
{
    using System.Threading.Tasks;

    public interface IInputBoundary
    {
        Task Handle(Request request);
    }
}
