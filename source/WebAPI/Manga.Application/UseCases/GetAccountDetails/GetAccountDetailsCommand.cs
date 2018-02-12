namespace Manga.Application.UseCases.GetAccountDetails
{
    using System;
    public class GetAccountDetailsCommand
    {
        public Guid AccountId { get; private set; }
        public GetAccountDetailsCommand(Guid accountId)
        {
            this.AccountId = accountId;
        }
    }
}
