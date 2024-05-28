namespace CorePlatform.Services.Core.Abstraction
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
