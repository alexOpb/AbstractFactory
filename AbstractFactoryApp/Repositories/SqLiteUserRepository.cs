using AbstractFactoryApp.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AbstractFactoryApp.Repositories;

public class SqLiteUserRepository : IUserRepository
{
    private readonly string _connectionString;

    public SqLiteUserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IEnumerable<User> GetUsers()
    {
        using var connection = new SqliteConnection(_connectionString);
        return connection.Query<User>("SELECT * FROM Users");
    }
}