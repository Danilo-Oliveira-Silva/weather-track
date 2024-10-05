using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.API.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = null!;
}