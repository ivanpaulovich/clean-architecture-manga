namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Register;

    public sealed class RegisterPresenter : IOutputPort
    {
        public RegisterPresenter()
        {
            this.Registers = new Collection<RegisterOutput>();
            this.AlreadyRegistered = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<RegisterOutput> Registers { get; }

        public Collection<string> AlreadyRegistered { get; }

        public Collection<string> Errors { get; }

        public void Standard(RegisterOutput output)
        {
            this.Registers.Add(output);
        }

        public void CustomerAlreadyRegistered(string message)
        {
            this.AlreadyRegistered.Add(message);
        }

        public void WriteError(string message)
        {
            this.Errors.Add(message);
        }
    }
}
