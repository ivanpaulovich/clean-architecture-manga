namespace Manga.Application.UseCases.CloseAccount
{
    using System;
    public class CloseResponse
    {
        public Guid AccountId { get; private set; }
        public CloseResponse()
        {

        }

        public CloseResponse(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
