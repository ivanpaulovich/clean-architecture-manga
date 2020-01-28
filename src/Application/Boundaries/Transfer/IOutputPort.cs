namespace Application.Boundaries.Transfer
{
    /// <summary>
    /// Transfer Output Port.
    /// </summary>
    public interface IOutputPort
        : IOutputPortStandard<TransferOutput>, IOutputPortNotFound
    {
    }
}
