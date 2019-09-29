namespace Manga.Application.Boundaries.Register
{
    public interface IOutputPort
    {
        void Standard(RegisterOutput registerOutput);
    }
}