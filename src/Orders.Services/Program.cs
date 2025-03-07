using Orders.Services;
using Orders.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructureServices();
builder.Services.AddServices();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseOrders();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
          {
              options.SwaggerEndpoint("/openapi/v1.json", "v1");
          });
}

app.Run();
