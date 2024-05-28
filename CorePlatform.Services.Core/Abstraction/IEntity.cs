namespace CorePlatform.Services.Core.Abstraction
{
    public interface IEntity
    {
        void ClearDomainEvents();
        IReadOnlyList<IDomainEvent> GetDomainEvents();
    }
}
