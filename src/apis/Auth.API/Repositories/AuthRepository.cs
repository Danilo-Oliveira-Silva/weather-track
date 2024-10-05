using Auth.API.Context;
using Auth.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Repositories;
public class AuthRepository : IAuthRepository
{
    private readonly IDataContext _context;

    public AuthRepository(IDataContext context)
    {
        _context = context;
    }

    public List<User> GetUsers()
    {
        return _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
    }

    public User? GetUsersByEmail(string Email)
    {
        return _context.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefault(u => u.Email == Email);
    }

    public User? AddUser(User user) 
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public UserRole? AddUserRole(int pUserId, int pRoleId)
    {
        UserRole userRole = new UserRole 
        {
            UserId = pUserId,
            RoleId = pRoleId
        };

        _context.UserRole.Add(userRole);
        _context.SaveChanges();
        return userRole;
    }

    public List<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }
}