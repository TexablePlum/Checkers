using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Application.Services;
using Checkers.Core.Entities;
using Checkers.Core.Enums;
using FluentAssertions;
using Xunit;

namespace Checkers.Tests.Services
{
    public class GameLogicServiceTests
    {
        private readonly GameLogicService _gameLogicService;

        public GameLogicServiceTests() 
        {
            _gameLogicService = new GameLogicService("testWhite", "testBlack");
        }

        [Fact]
        public void TryMakeMove_ValidMove_ReturnsTrue()
        {
            var move = new Move(2, 5, 3, 4, false);
            var result = _gameLogicService.TryMakeMove(move);

            result.Should().BeTrue("Because the move is valid according to game rules !");
        }

        [Fact]
        public void TryMakeMove_InvalidMove_ReturnsFalse() {
            var move = new Move(2, 5, 2, 4, false);
            var result = _gameLogicService.TryMakeMove(move);
            result.Should().BeFalse("Because pieces cannot move vertically !");
        }

        [Fact]
        public void TryMakeMove_AfterValidMove_PlayerShouldChange()
        {
            var move = new Move(2, 5, 3, 4, false);
            _gameLogicService.TryMakeMove(move);
            _gameLogicService.CurrentPlayer.Color.Should().Be(PieceColor.Black, "Because after a valid move, player should switch to black !");
        }
    }
}
