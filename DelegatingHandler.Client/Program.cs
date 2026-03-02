using DelegatingHandler.Client.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<OutboundLoggingHandler>();

builder.Services.AddHttpClient("DelegatingHandlerServer", client =>
{
    client.BaseAddress = new Uri("http://localhost:5145");
}).AddHttpMessageHandler<OutboundLoggingHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();