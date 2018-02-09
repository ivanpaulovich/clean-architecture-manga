//namespace Acerola.UI.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using System;
//    using System.Threading.Tasks;
//    using Acerola.Application.Queries;
//    using Acerola.Domain.Accounts;
//    using System.Collections.Generic;
//    using Acerola.Application.DTO;
//    using Acerola.Application.UseCases;
//    using Acerola.Application.Boundary;

//    [Route("api/[controller]")]
//    public class AccountsController : Controller
//    {
//        private readonly IBoundary deposit;
//        private readonly IWithdraw withdraw;
//        private readonly IBoundary close;
//        private readonly IAccountsQueries accountsQueries;

//        public AccountsController(
//            IBoundary deposit, 
//            IWithdraw withdraw,
//            IBoundary close,
//            IAccountsQueries accountsQueries)
//        {
//            if (deposit == null)
//                throw new ArgumentNullException(nameof(deposit));

//            if (withdraw == null)
//                throw new ArgumentNullException(nameof(withdraw));

//            if (close == null)
//                throw new ArgumentNullException(nameof(close));

//            if (accountsQueries == null)
//                throw new ArgumentNullException(nameof(accountsQueries));

//            this.deposit = deposit;
//            this.withdraw = withdraw;
//            this.close = close;
//            this.accountsQueries = accountsQueries;
//        }

//        /// <summary>
//        /// Deposit from an account
//        /// </summary>
//        [HttpPatch("Deposit")]
//        public async Task<IActionResult> Deposit([FromBody]Request message)
//        {
//            Credit credit = await deposit.Handle(message);
//            return Ok();
//        }

//        /// <summary>
//        /// Withdraw from an account
//        /// </summary>
//        [HttpPatch("Withdraw")]
//        public async Task<IActionResult> Withdraw([FromBody]Interactor message)
//        {
//            Debit debit = await withdraw.Handle(message);
//            return Ok();
//        }

//        /// <summary>
//        /// Close an account
//        /// </summary>
//        [HttpDelete]
//        public async Task<IActionResult> Close([FromBody]Interactor message)
//        {
//            await close.Handle(message);
//            return Ok();
//        }

//        /// <summary>
//        /// Get an account balance
//        /// </summary>
//        [HttpGet("{id}", Name = "GetAccount")]
//        public async Task<IActionResult> Get(Guid id)
//        {
//            var account = await accountsQueries.GetAccount(id);

//            return Ok(account);
//        }

//        /// <summary>
//        /// List all accounts
//        /// </summary>
//        [HttpGet]
//        public async Task<IActionResult> List([FromQuery]Guid? customerId)
//        {
//            IEnumerable<AccountData> accounts = null;

//            if (customerId.HasValue)
//            {
//                accounts = await accountsQueries.Get(customerId.Value);
//                return Ok(accounts);
//            }

//            accounts = await accountsQueries.GetAll();
//            return Ok(accounts);
//        }
//    }
//}
