using Auth.API.DTOs;
using Auth.API.Repositories;
using Auth.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthUseCase _authUseCase;
    public AuthController(IAuthUseCase authUseCase)
    {
        _authUseCase = authUseCase;
    }

    [HttpPost]
    public IActionResult Auth([FromBody] AuthRequest authRequest)
    {
        try {
            return Ok(_authUseCase.Execute(authRequest));
        } catch(Exception ex) {
            return BadRequest(new { message = ex.Message });
        }
        
    }
}