namespace Manga.Application.Boundaries.CloseAccount
{
    public interface IOutputPort
    {
        void Standard(CloseAccountOutput closeAccountOutput);
    }
}
