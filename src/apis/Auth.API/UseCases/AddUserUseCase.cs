using Auth.API.DTOs;
using Auth.API.Models;
using Auth.API.Repositories;

namespace Auth.API.UseCases;

public class AddUserUseCase : IAddUserUseCase
{
    private readonly IAuthRepository _authRepository;
    private readonly IAuthUseCase _authUseCase;
    public AddUserUseCase(IAuthRepository authRepository, IAuthUseCase authUseCase)
    {
        _authRepository = authRepository;
        _authUseCase = authUseCase;
    }
    public AuthResponse Execute(AddUserRequest addUserRequest)
    {
        User user = new User {
            Email = addUserRequest.Email,
            Name = addUserRequest.Name,
            Password = addUserRequest.Password
        };
        User? newUser = _authRepository.AddUser(user);

        foreach(var roleId in addUserRequest.Roles!)
        {
            _authRepository.AddUserRole(newUser!.UserId, roleId);
        }

        AuthRequest authRequest = new AuthRequest {
            Email = newUser!.Email,
            Password = newUser!.Password
        };
        return _authUseCase.Execute(authRequest);

    }
}