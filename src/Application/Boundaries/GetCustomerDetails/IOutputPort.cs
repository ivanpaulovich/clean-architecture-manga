namespace Application.Boundaries.GetCustomerDetails
{
    /// <summary>
    /// Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<GetCustomerDetailsOutput>, IOutputPortNotFound
    {
    }
}
