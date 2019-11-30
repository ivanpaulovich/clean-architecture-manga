namespace Domain.Accounts.Credits
{
    public interface ICredit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}
