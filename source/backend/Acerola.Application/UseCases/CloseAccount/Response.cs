namespace Acerola.Application.UseCases.CloseAccount
{
    using System;
    public class Response
    {
        public Guid AccountId { get; private set; }
        public Response()
        {

        }

        public Response(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
