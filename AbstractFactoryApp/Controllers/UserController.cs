using AbstractFactoryApp.Factories;
using Microsoft.AspNetCore.Mvc;

namespace AbstractFactoryApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IDatabaseFactory _databaseFactory;

    public UserController(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
    }
    
    [HttpGet(Name = "GetUser")]
    public IActionResult Get()
    {
        var userRepository = _databaseFactory.CreateUserRepository();
        var users = userRepository.GetUsers();
        return Ok(users);
    }
}