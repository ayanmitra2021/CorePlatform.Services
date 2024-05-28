using System.Data;

namespace CorePlatform.Services.UseCases.Abstraction.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
