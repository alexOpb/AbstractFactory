using AbstractFactoryApp.Repositories;

namespace AbstractFactoryApp.Factories;

public class MssqlDatabaseFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public MssqlDatabaseFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IUserRepository CreateUserRepository()
    {
        return new MssqlUserRepository(_connectionString);
    }
}