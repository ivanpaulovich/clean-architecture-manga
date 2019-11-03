namespace Application.Boundaries.Register
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(RegisterInput registerInput);
    }
}