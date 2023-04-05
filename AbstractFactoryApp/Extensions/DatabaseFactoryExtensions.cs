using AbstractFactoryApp.Factories;

namespace AbstractFactoryApp.Extensions;

public static class DatabaseFactoryExtensions
{
    public static IServiceCollection AddDatabaseFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database");
        var databaseType = databaseConfig.GetValue<DatabaseType>("DatabaseType");
        
        switch (databaseType)
        {
            case DatabaseType.MSSQL:
                services.AddSingleton<IDatabaseFactory>(
                    new MssqlDatabaseFactory(databaseConfig.GetConnectionString("MSSQL")));
                break;
            case DatabaseType.PostgreSQL:
                services.AddSingleton<IDatabaseFactory>(
                    new PostgreSqlDatabaseFactory(databaseConfig.GetConnectionString("PostgreSQL")));
                break;
            case DatabaseType.SQLite:
                services.AddSingleton<IDatabaseFactory>(
                    new SqLiteDatabaseFactory(databaseConfig.GetConnectionString("SQLite")));
                break;
            case DatabaseType.Undefined:
            default:
                throw new InvalidOperationException($"Unsupported database type '{databaseType}'.");
        }

        return services;
    }
}