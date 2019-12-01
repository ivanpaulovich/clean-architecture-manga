namespace Application.Boundaries.Register
{
    public interface IOutputPort
        : IOutputPortStandard<RegisterOutput>
    {
        void CustomerAlreadyRegistered(string message);
    }
}