namespace Application.UseCases.GetAccounts;

using System.Collections.Generic;
using Domain;

public sealed class GetAccountPresenter : IOutputPort
{
    public IList<Account>? Accounts { get; private set; }
    public void Ok(IList<Account> accounts) => this.Accounts = accounts;
}
