namespace Application.Boundaries
{
    using System.Threading.Tasks;

    public interface IUseCase<in TUseCaseInput>
        where TUseCaseInput : IUseCaseInput
    {
        Task Execute(TUseCaseInput input);
    }
}