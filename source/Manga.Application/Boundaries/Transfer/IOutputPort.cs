namespace Manga.Application.Boundaries.Transfer
{
    public interface IOutputPort
    {
        void Standard(TransferOutput transferOutput);
    }
}