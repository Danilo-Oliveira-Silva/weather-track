namespace Auth.API.DTOs;

public record AuthRequest
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}