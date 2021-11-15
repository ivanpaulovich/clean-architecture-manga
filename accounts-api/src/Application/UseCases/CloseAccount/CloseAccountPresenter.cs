using Domain;

namespace Application.UseCases.CloseAccount;

/// <summary>
///     Close Account Presenter.
/// </summary>
public sealed class CloseAccountPresenter : IOutputPort
{
    public Account? Account { get; private set; }
    public bool NotFoundOutput { get; private set; }
    public bool HasFundsOutput { get; private set; }
    public bool InvalidOutput { get; private set; }
    public void Invalid() => this.InvalidOutput = true;
    public void NotFound() => this.NotFoundOutput = true;
    public void HasFunds() => this.HasFundsOutput = true;
    public void Ok(Account account) => this.Account = account;
}
