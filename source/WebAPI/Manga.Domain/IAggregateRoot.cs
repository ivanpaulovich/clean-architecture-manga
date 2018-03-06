namespace Manga.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}