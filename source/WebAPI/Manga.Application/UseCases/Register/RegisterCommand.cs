namespace Manga.Application.UseCases.Register
{
    public class RegisterCommand
    {
        public string PIN { get; private set; }
        public string Name { get; private set; }
        public double InitialAmount { get; private set; }

        public RegisterCommand(string pin, string name, double initialAmount)
        {
            this.PIN = pin;
            this.Name = name;
            this.InitialAmount = initialAmount;
        }
    }
}
