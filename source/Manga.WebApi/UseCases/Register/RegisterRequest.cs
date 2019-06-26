namespace Manga.WebApi.UseCases.Register
{
    public class RegisterRequest
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public double InitialAmount { get; set; }
    }
}