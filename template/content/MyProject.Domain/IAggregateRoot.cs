namespace MyProject.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}