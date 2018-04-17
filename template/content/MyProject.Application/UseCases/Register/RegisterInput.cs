namespace MyProject.Application.UseCases.Register
{
    public class RegisterInput
    {
        public string PIN { get; private set; }
        public string Name { get; private set; }
        public double InitialAmount { get; private set; }

        public RegisterInput(string pin, string name, double initialAmount)
        {
            this.PIN = pin;
            this.Name = name;
            this.InitialAmount = initialAmount;
        }
    }
}
