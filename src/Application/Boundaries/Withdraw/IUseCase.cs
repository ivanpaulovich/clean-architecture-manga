namespace Application.Boundaries.Withdraw
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(WithdrawInput withdrawInput);
    }
}