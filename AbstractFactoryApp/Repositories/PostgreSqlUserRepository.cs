using AbstractFactoryApp.Models;
using Dapper;
using Npgsql;

namespace AbstractFactoryApp.Repositories;

public class PostgreSqlUserRepository : IUserRepository
{
    private readonly string _connectionString;

    public PostgreSqlUserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IEnumerable<User> GetUsers()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        return connection.Query<User>("SELECT * FROM Users");
    }
}