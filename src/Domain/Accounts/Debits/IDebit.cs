namespace Domain.Accounts.Debits
{
    public interface IDebit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}
