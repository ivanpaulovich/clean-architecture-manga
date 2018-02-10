namespace Acerola.Application.UseCases.Register
{
    using System;
    public class Response
    {
        public Guid CustomerId { get; private set; }
        public string Personnummer { get; private set; }
        public string Name { get; private set; }

        public Response(Guid customerId, string personnummer, string name)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
        }
    }
}
