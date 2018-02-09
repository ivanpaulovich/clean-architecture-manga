namespace Acerola.Domain
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        public int Version { get; private set; }

        public AggregateRoot()
        {
            Version = 0;
        }
    }
}
