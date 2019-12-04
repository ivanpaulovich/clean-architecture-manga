namespace Application.Boundaries
{
    public interface IOutputPortStandard<in TUseCaseOutput>
        where TUseCaseOutput : IUseCaseOutput
    {
        void Standard(TUseCaseOutput output);
    }
}
