using System.Text;
using System.Text.Json.Serialization;
using Auth.API.Context;
using Auth.API.Repositories;
using Auth.API.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Variáveis de Ambiente
var PORT = builder.Configuration["PORT"] ?? "5001";
var DBSERVER = builder.Configuration["DBSERVER"] ?? "localhost";
var DBDATABASE = builder.Configuration["DBDATABASE"] ?? "farm-data";
var DBUSER = builder.Configuration["DBUSER"] ?? "root";
var DBPASSWORD = builder.Configuration["DBPASSWORD"] ?? "root";
var DBPORT = builder.Configuration["DBPORT"] ?? "3306";
var JWTSECRET =  builder.Configuration["JWTSECRET"] ?? "4d82a63bbdc67c1e4784ed6587f3730c";

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = $"Server={DBSERVER};Database={DBDATABASE};User Id={DBUSER};Password={DBPASSWORD};Port={DBPORT}";
builder.Services.AddDbContext<DataContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthUseCase, AuthUseCase>();
builder.Services.AddScoped<IAddUserUseCase, AddUserUseCase>();
builder.Services.AddScoped<IGetRolesUseCase, GetRolesUseCase>();

builder.WebHost.UseUrls($"http://*:{PORT}");

builder.Services.AddAuthentication(options =>
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSECRET))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
