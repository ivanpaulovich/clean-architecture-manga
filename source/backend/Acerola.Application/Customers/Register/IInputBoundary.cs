namespace Acerola.Application.Customers.Register
{
    using System.Threading.Tasks;

    public interface IInputBoundary
    {
        Task Handle(Request request);
    }
}
