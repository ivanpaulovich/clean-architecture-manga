namespace Application.Boundaries.Deposit
{
    using System.Threading.Tasks;

    public interface IUseCase
    {
        Task Execute(DepositInput depositInput);
    }
}