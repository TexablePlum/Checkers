using Microsoft.AspNetCore.SignalR;

namespace Checkers.API.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMove(string moveData)
        {
            await Clients.Others.SendAsync("ReceiveMove", moveData);
        }
    }
}
