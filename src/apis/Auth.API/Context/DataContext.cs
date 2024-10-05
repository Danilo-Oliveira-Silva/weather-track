using Microsoft.EntityFrameworkCore;
using Auth.API.Models;

namespace Auth.API.Context;

public class DataContext : DbContext, IDataContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRole> UserRole { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
       

        modelBuilder.Entity<UserRole>().HasKey(ur => ur.UserId);
        modelBuilder.Entity<UserRole>().HasKey(ur => ur.RoleId);
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
        
    }


    
}
