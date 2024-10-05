using Auth.API.DTOs;

namespace Auth.API.UseCases;

public interface IAuthUseCase
{
    AuthResponse Execute(AuthRequest authRequest);
}