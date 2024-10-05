using Auth.API.Models;
namespace Auth.API.Repositories;
public interface IAuthRepository
{
    List<User> GetUsers();
    User? GetUsersByEmail(string Email);
    User? AddUser(User user);
    UserRole? AddUserRole(int UserId, int RoleId);
    List<Role> GetRoles();
}