using Checkers.Application.Services;
using Checkers.Core.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Checkers.API.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameLogicService _gameLogicService;

        public GameHub(GameLogicService gameLogicService)
        {
            _gameLogicService = gameLogicService;
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            Clients.Caller.SendAsync("UpdateBoard", _gameLogicService.GameBoard);

            return base.OnConnectedAsync();
        }

        public async Task MakeMove(Move move) 
        {
            var isMoveValid = _gameLogicService.TryMakeMove(move);

            if (isMoveValid)
            {
                Console.WriteLine($"Valid move made: {move.FromX},{move.FromY} to {move.ToX},{move.ToY}");
                await Clients.All.SendAsync("UpdateBoard", _gameLogicService.GameBoard);
            }
            else 
            {
                Console.WriteLine($"Invalid move attempt: {move.FromX}, {move.FromY} to {move.ToX}, {move.ToY}");
                await Clients.Caller.SendAsync("InvalidMove: ", move);
            }
        }
    }
}
