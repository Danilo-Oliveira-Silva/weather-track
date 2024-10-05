using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("routes.json");
builder.Services.AddOcelot(builder.Configuration);

var port = builder.Configuration["PORT"];
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

await app.UseOcelot();

app.Run();
