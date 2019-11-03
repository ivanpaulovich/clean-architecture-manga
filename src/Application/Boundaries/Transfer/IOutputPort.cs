using Domain;

namespace Application.Boundaries.Transfer
{
    public interface IOutputPort
    {
        void Standard(TransferOutput transferOutput);
        void NotFound(string message);
    }
}