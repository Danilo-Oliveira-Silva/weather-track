namespace Auth.API.DTOs;

public record AddUserRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int[]? Roles { get; set; }
}