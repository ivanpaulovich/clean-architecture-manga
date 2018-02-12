namespace Manga.UI.Model
{
    using System;

    public class RegisterModel
    {
        public Guid CustomerId { get; }
        public string Personnummer { get; }
        public string Name { get; }

        public RegisterModel(Guid customerId, string perssonnummer, string name)
        {
            CustomerId = customerId;
            Personnummer = perssonnummer;
            Name = name;
        }
    }
}
