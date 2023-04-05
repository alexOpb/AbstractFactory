using AbstractFactoryApp.Repositories;

namespace AbstractFactoryApp.Factories;

public class PostgreSqlDatabaseFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public PostgreSqlDatabaseFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IUserRepository CreateUserRepository()
    {
        return new PostgreSqlUserRepository(_connectionString);
    }
}