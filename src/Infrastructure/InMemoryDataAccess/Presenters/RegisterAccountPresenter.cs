namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.RegisterAccount;

    public sealed class RegisterAccountPresenter : IOutputPort
    {
        public Collection<RegisterAccountOutput> Registers { get; }

        public RegisterAccountPresenter()
        {
            Registers = new Collection<RegisterAccountOutput>();
        }

        public void Standard(RegisterAccountOutput output)
        {
            Registers.Add(output);
        }
    }
}
