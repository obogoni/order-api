using Orders.Services;
using Orders.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();

var app = builder.Build();

app.UseCreateOrder();
app.Run();
