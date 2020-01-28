namespace Application.Boundaries.GetAccountDetails
{
    /// <summary>
    /// Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<GetAccountDetailsOutput>, IOutputPortNotFound
    {
    }
}
