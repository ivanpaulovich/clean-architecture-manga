namespace Application.Boundaries.GetAccountDetails
{
    public interface IOutputPort
        : IOutputPortStandard<GetAccountDetailsOutput>, IOutputPortNotFound
    {
    }
}