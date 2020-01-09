namespace Application.Boundaries.CloseAccount
{
    /// <summary>
    /// Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<CloseAccountOutput>, IOutputPortNotFound
    {
    }
}
