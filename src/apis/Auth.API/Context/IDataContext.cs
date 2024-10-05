using Microsoft.EntityFrameworkCore;
using Auth.API.Models;

namespace Auth.API.Context;

public interface IDataContext 
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public int SaveChanges();
}
