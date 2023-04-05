using AbstractFactoryApp.Repositories;

namespace AbstractFactoryApp.Factories;

public class SqLiteDatabaseFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public SqLiteDatabaseFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IUserRepository CreateUserRepository()
    {
        return new SqLiteUserRepository(_connectionString);
    }
}