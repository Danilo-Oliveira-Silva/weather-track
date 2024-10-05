using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Weather.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var Secret = Environment.GetEnvironmentVariable("JWTSECRET") ?? "4d82a63bbdc67c1e4784ed6587f3730c";

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret))
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            options.AddPolicy("tech-lead", policy => policy.RequireClaim(ClaimTypes.Role, "tech-lead"));
            options.AddPolicy("head", policy => policy.RequireClaim(ClaimTypes.Role, "head"));
        });


        return services;
    }
}