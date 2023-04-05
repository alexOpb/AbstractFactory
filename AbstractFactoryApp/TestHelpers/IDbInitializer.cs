namespace AbstractFactoryApp.TestHelpers;

public interface IDbInitializer
{
    Task InitializeAsync(string connectionString);
}