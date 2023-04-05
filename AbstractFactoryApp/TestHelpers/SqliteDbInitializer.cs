using Dapper;
using Microsoft.Data.Sqlite;

namespace AbstractFactoryApp.TestHelpers;

public class SqliteDbInitializer : IDbInitializer
{
    /// <summary>
    /// Инициализирует БД Sqlite таблицами и тестовыми данными
    /// </summary>
    /// <param name="connectionString"></param>
    public async Task InitializeAsync(string connectionString)
    {
        if (!File.Exists("mydatabase.db"))
        {
            File.Create("mydatabase.db").Close();
        }

        await using var connection = new SqliteConnection(connectionString);

        const string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL
                );
            ";

        await connection.ExecuteAsync(createUsersTable);
        
        const string insertTestData = @"
                INSERT OR IGNORE INTO Users (Id, FirstName, LastName) VALUES
                    (1, 'John', 'Doe'),
                    (2, 'Jane', 'Doe'),
                    (3, 'Alice', 'Johnson');
            ";

        await connection.ExecuteAsync(insertTestData);
    }
}