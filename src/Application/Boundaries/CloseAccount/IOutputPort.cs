using Domain;

namespace Application.Boundaries.CloseAccount
{
    public interface IOutputPort
    {
        void Standard(CloseAccountOutput closeAccountOutput);
        void NotFound(string message);
    }
}