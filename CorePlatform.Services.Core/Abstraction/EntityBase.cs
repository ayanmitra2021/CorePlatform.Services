namespace CorePlatform.Services.Core.Abstraction
{
    public abstract class EntityBase
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public int Id { get; set; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent ev)
        {
            _domainEvents.Add(ev);
        }
    }
}
