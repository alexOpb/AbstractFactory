namespace AbstractFactoryApp.TestHelpers;

public static class DbExtension
{
    public static async Task<IServiceCollection> AddDbInitializer(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database");
        var databaseType = databaseConfig.GetValue<string>("DatabaseType");
        var connectionString = databaseConfig.GetConnectionString(databaseType);
        var dbInitializer = GetDbInitializer(databaseType);
        await dbInitializer.InitializeAsync(connectionString);
        services.AddSingleton<IDbInitializer>(dbInitializer);

        return services;
    }

    private static IDbInitializer GetDbInitializer(string databaseType)
    {
        return databaseType.ToLowerInvariant() switch
        {
            "mssql" => new MssqlDbInitializer(),
            "postgresql" => new PostgreSQLDbInitializer(),
            "sqlite" => new SqliteDbInitializer(),
            _ => throw new ArgumentException($"Invalid database type: {databaseType}")
        };
    }
}