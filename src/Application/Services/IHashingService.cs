namespace Application.Services
{
    using Domain.ValueObjects;

    public interface IHashingService
    {
        Password Hash(string password, int iterations = 10000);

        bool IsHashSupported(string hashString);

        bool Verify(string password, string hashedPassword);
    }
}
