using System.Data.SqlClient;
using Dapper;

namespace AbstractFactoryApp.TestHelpers;

public class MssqlDbInitializer : IDbInitializer
{
    /// <summary>
    /// Инициализирует БД Sqlite таблицами и тестовыми данными
    /// </summary>
    /// <param name="connectionString"></param>
    public async Task InitializeAsync(string connectionString)
    {
        await using var connection = new SqlConnection(connectionString);

        const string createUsersTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                    CREATE TABLE Users (
                        Id INT PRIMARY KEY,
                        FirstName NVARCHAR(50) NOT NULL,
                        LastName NVARCHAR(50) NOT NULL
                    );
                ";

        await connection.ExecuteAsync(createUsersTable);

        const string insertTestData = @"
                    IF NOT EXISTS (SELECT * FROM Users WHERE Id = 1)
                    INSERT INTO Users (Id, FirstName, LastName) VALUES
                        (1, 'John', 'Doe'),
                        (2, 'Jane', 'Doe'),
                        (3, 'Alice', 'Johnson');
                ";

        await connection.ExecuteAsync(insertTestData);
    }   
}