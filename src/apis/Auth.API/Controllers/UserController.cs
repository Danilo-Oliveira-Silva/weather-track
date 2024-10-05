using Auth.API.DTOs;
using Auth.API.Repositories;
using Auth.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly IAddUserUseCase _addUserUseCase;
    public UserController(IAddUserUseCase addUserUseCase)
    {
        _addUserUseCase = addUserUseCase;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] AddUserRequest addUserRequest)
    {
        try {
            return Ok(_addUserUseCase.Execute(addUserRequest));
        } catch(Exception ex) {
            return BadRequest(new { message = ex.Message });
        }
        
    }
}