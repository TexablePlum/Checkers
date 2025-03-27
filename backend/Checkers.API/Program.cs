using Checkers.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Dodaj us�ugi SignalR
builder.Services.AddSignalR();

// Pozosta�a konfiguracja
builder.Services.AddControllers();

var app = builder.Build();

// Routing SignalR
app.MapHub<GameHub>("/gameHub");

// Domy�lne ustawienia
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
