namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Register;

    public sealed class RegisterPresenter : IOutputPort
    {
        public Collection<RegisterOutput> Registers { get; }

        public RegisterPresenter()
        {
            Registers = new Collection<RegisterOutput>();
        }

        public void Standard(RegisterOutput output)
        {
            Registers.Add(output);
        }
    }
}