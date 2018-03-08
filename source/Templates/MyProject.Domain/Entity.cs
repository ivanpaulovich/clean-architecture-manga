namespace MyProject.Domain
{
    using System;

    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
