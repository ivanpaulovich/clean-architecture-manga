namespace Application.Boundaries.GetCustomerDetails
{
    public interface IOutputPort
        : IOutputPortStandard<GetCustomerDetailsOutput>, IOutputPortNotFound
    {
    }
}