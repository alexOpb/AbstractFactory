using AbstractFactoryApp.Repositories;

namespace AbstractFactoryApp.Factories;

public interface IDatabaseFactory
{
    IUserRepository CreateUserRepository();
}