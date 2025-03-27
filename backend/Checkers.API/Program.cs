using Checkers.API.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Dodaj us³ugi SignalR
builder.Services.AddSignalR();

// Pozosta³a konfiguracja
builder.Services.AddControllers();

var app = builder.Build();

// Routing SignalR
app.MapHub<GameHub>("/gameHub");

// Domyœlne ustawienia
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
