using Auth.API.DTOs;
using Auth.API.Models;

namespace Auth.API.UseCases;

public interface IGetRolesUseCase
{
    List<Role> Execute();
}