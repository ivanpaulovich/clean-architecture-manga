namespace Acerola.Application.Customers.Register
{
    public interface IOutputBoundary
    {
        void Handle(Response response);
    }
}
