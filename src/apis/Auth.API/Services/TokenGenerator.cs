using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Auth.API.Services;

public class TokenGenerator
{
    public string Generate(string Email, List<string> roles)
    {
        var Secret = Environment.GetEnvironmentVariable("JWTSECRET") ?? "4d82a63bbdc67c1e4784ed6587f3730c";
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Email, Email));
        foreach(string role in roles)
        {
            claims.AddClaim(new Claim(ClaimTypes.Role, role));
        }
    
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claims,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
                SecurityAlgorithms.HmacSha256Signature
            ),
            Expires = DateTime.Now.AddDays(1)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}