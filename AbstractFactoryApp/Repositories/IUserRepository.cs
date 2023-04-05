using AbstractFactoryApp.Models;

namespace AbstractFactoryApp.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetUsers();
}