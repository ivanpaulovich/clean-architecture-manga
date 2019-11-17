namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Register;

    public sealed class RegisterPresenter : IOutputPort
    {
        public Collection<RegisterOutput> Registers { get; }
        public Collection<string> AlreadyRegistered { get; }

        public RegisterPresenter()
        {
            Registers = new Collection<RegisterOutput>();
            AlreadyRegistered = new Collection<string>();
        }

        public void Standard(RegisterOutput output)
        {
            Registers.Add(output);
        }

        public void CustomerAlreadyRegistered(string message)
        {
            AlreadyRegistered.Add(message);
        }
    }
}