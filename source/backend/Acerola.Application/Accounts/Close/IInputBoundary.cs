namespace Acerola.Application.Accounts.Close
{
    using System.Threading.Tasks;

    public interface IInputBoundary
    {
        Task Handle(Request request);
    }
}
