namespace MyProject.Domain
{
    using System;

    public class Entity : IEntity
    {
        private Guid id = Guid.NewGuid();
        public virtual Guid Id
        {
            get
            {
                return id;
            }
            protected set
            {
                id = value;
            }
        }
    }
}
