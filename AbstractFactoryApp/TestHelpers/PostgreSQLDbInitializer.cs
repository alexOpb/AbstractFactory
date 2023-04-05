using Dapper;
using Npgsql;

namespace AbstractFactoryApp.TestHelpers;

public class PostgreSQLDbInitializer : IDbInitializer
{
    /// <summary>
    /// Инициализирует БД Sqlite таблицами и тестовыми данными
    /// </summary>
    /// <param name="connectionString"></param>
    public async Task InitializeAsync(string connectionString)
    {
        await using var connection = new NpgsqlConnection(connectionString);

        const string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY,
                        FirstName VARCHAR(50) NOT NULL,
                        LastName VARCHAR(50) NOT NULL
                    );
                ";

        await connection.ExecuteAsync(createUsersTable);

        const string insertTestData = @"
                    INSERT INTO Users (Id, FirstName, LastName)
                    VALUES
                        (1, 'John', 'Doe'),
                        (2, 'Jane', 'Doe'),
                        (3, 'Alice', 'Johnson')
                    ON CONFLICT (Id) DO NOTHING;
                ";

        await connection.ExecuteAsync(insertTestData);
    }  
}