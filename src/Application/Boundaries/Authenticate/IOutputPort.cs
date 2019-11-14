namespace Application.Boundaries.Authenticate
{
    public interface IOutputPort
        : IOutputPortStandard<AuthenticateOutput>, IOutputPortNotFound { }
}
