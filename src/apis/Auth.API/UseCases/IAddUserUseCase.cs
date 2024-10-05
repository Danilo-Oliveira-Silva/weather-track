using Auth.API.DTOs;

namespace Auth.API.UseCases;

public interface IAddUserUseCase
{
    AuthResponse Execute(AddUserRequest addUserRequest);
}