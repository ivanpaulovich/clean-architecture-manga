namespace Domain.Accounts
{
    using System.Threading.Tasks;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    public class AccountService
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IAccountFactory accountFactory,
            IAccountRepository accountRepository)
        {
            _accountFactory = accountFactory;
            _accountRepository = accountRepository;
        }

        public async Task<IAccount> OpenCheckingAccount(CustomerId customerId, PositiveMoney amount)
        {
            var account = _accountFactory.NewAccount(customerId);
            var credit = account.Deposit(_accountFactory, amount);
            await _accountRepository.Add(account, credit);

            return account;
        }

        public async Task<IDebit> Withdraw(IAccount account, PositiveMoney amount)
        {
            var debit = account.Withdraw(_accountFactory, amount);
            await _accountRepository.Update(account, debit);

            return debit;
        }

        public async Task<ICredit> Deposit(IAccount account, PositiveMoney amount)
        {
            var credit = account.Deposit(_accountFactory, amount);
            await _accountRepository.Update(account, credit);

            return credit;
        }
    }
}
