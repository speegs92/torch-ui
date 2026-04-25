using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Playground.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
