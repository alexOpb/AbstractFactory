using System.Data.SqlClient;
using AbstractFactoryApp.Models;
using Dapper;

namespace AbstractFactoryApp.Repositories;

public class MssqlUserRepository : IUserRepository
{
    private readonly string _connectionString;

    public MssqlUserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IEnumerable<User> GetUsers()
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Query<User>("SELECT * FROM Users");
    }
}