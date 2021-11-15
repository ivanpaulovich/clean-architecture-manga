namespace Application.UseCases.Transfer;

using Domain;
using Domain.Credits;
using Domain.Debits;

public sealed class TransferPresenter : IOutputPort
{
    public Account? OriginAccount { get; private set; }
    public Account? DestinationAccount { get; private set; }
    public Credit? Credit { get; private set; }
    public Debit? Debit { get; private set; }
    public bool InvalidOutput { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public bool OutOfFundsOutput { get; private set; }
    public void Invalid() => this.InvalidOutput = true;
    public void NotFound() => this.NotFoundOutput = true;

    public void Ok(Account originAccount, Debit debit, Account destinationAccount, Credit credit)
    {
        this.OriginAccount = originAccount;
        this.Debit = debit;
        this.DestinationAccount = destinationAccount;
        this.Credit = credit;
    }

    public void OutOfFunds() => this.OutOfFundsOutput = true;
}
