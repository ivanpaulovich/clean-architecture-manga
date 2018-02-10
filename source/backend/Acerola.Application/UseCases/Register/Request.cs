namespace Acerola.Application.UseCases.Register
{
    public class Request
    {
        public string PIN { get; }
        public string Name { get; }
        public double InitialAmount { get; }

        public Request(string pin, string name, double initialAmount)
        {
            this.PIN = pin;
            this.Name = name;
            this.InitialAmount = initialAmount;
        }
    }
}
