using Checkers.API.Hubs;
using Checkers.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<GameLogicService>(provider => new GameLogicService("Player1", "Player2"));

var app = builder.Build();

app.MapHub<GameHub>("/checkersHub");
app.MapGet("/", () => "Checkers API is running!");

app.Run();