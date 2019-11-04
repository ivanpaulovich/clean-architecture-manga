namespace Application.Boundaries.Transfer
{
    public interface IOutputPort
        : IOutputPortStandard<TransferOutput>, IOutputPortNotFound { }
}