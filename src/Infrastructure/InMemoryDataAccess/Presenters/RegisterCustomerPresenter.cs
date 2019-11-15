namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.RegisterCustomer;

    public sealed class RegisterCustomerPresenter : IOutputPort
    {
        public Collection<RegisterCustomerOutput> Registers { get; }

        public RegisterCustomerPresenter()
        {
            Registers = new Collection<RegisterCustomerOutput>();
        }

        public void Standard(RegisterCustomerOutput output)
        {
            Registers.Add(output);
        }
    }
}
