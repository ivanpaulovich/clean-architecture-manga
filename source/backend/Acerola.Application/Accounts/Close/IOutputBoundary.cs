namespace Acerola.Application.Accounts.Close
{
    public interface IOutputBoundary
    {
        void Populate(ResponseModel response);
    }
}
