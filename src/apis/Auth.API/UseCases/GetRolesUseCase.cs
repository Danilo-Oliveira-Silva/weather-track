using Auth.API.DTOs;
using Auth.API.Models;
using Auth.API.Repositories;

namespace Auth.API.UseCases;

public class GetRolesUseCase : IGetRolesUseCase
{
     private readonly IAuthRepository _authRepository;
    public GetRolesUseCase(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    public List<Role> Execute()
    {
        return _authRepository.GetRoles();
    }
}