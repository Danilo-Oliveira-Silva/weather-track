using Auth.API.DTOs;
using Auth.API.Repositories;
using Auth.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{

    private readonly IGetRolesUseCase _getRolesUseCase;
    public RoleController(IGetRolesUseCase getRolesUseCase)
    {
        _getRolesUseCase = getRolesUseCase;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try {
            return Ok(_getRolesUseCase.Execute());
        } catch(Exception ex) {
            return BadRequest(new { message = ex.Message });
        }
        
    }
}