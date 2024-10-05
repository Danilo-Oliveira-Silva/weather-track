using System.Text.Json.Serialization;
using Auth.API.DTOs;
using Auth.API.Models;
using Auth.API.Repositories;
using Auth.API.Services;
using Newtonsoft.Json;

namespace Auth.API.UseCases;

public class AuthUseCase : IAuthUseCase
{
    private readonly IAuthRepository _authRepository;
    public AuthUseCase(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    public AuthResponse Execute(AuthRequest authRequest)
    {
        User? user = _authRepository.GetUsersByEmail(authRequest.Email!);
        if (user == null) throw new Exception("Incorrect user or password");
        if (user.Password != authRequest.Password) throw new Exception("Incorrect user or password");

        var roles = user.UserRoles.Select(ur => 
            ur.Role!.Name
        ).ToList();

        var tokenGenerator = new TokenGenerator();
        var token = tokenGenerator.Generate(user.Email!, roles!);
        return new AuthResponse { token = token };
    }
}