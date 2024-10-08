using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.API.Models;


public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string? Name { get; set; }
    public ICollection<UserRole>? UserRoles { get; set; }
}