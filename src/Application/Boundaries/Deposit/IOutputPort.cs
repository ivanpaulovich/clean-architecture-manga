using Domain;

namespace Application.Boundaries.Deposit
{
    public interface IOutputPort
    {
        void Standard(DepositOutput depositOutput);
        void NotFound(string message);
    }
}