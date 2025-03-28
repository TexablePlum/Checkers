using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Core.Entities;
using Checkers.Core.Enums;

namespace Checkers.Application.Services
{
    public class GameLogicService
    {
        public Board GameBoard { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Player WhitePlayer { get; private set; }
        public Player BlackPlayer { get; private set; }

        public GameLogicService(string whitePlayerName, string blackPlayerName)
        {
            WhitePlayer = new Player (whitePlayerName, PieceColor.White);
            BlackPlayer = new Player (blackPlayerName, PieceColor.Black);

            CurrentPlayer = WhitePlayer;
            
            GameBoard = new();
        }

        public bool TryMakeMove(Move move)
        {
            if (!GameBoard.ValidateMove(move, CurrentPlayer.Color))
            {
                return false;
            }

            ExecuteMove(move);

            SwitchPlayer();

            return true;
        }

        private void ExecuteMove(Move move) { 

            var piece = GameBoard.Pieces.FirstOrDefault(p => p.X == move.FromX && p.Y == move.FromY);

            if (piece == null)
            {
                throw new InvalidOperationException("Piece not find!");
            }

            piece.X = move.ToX;
            piece.Y = move.ToY;

            if (move.IsCapture)
            {
                var capturedX = (move.FromX + move.ToX) / 2;
                var capturedY = (move.FromY + move.ToY) / 2;
                var capturedPiece = GameBoard.Pieces.FirstOrDefault(p => p.X == capturedX && p.Y == capturedY);

                if (capturedPiece != null)
                {
                    GameBoard.Pieces.Remove(capturedPiece);
                }
            }

            if ((piece.Color == PieceColor.White && piece.Y == 0) || (piece.Color == PieceColor.Black && piece.Y == 7))
            {
                piece.IsKing = true;
            }
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == WhitePlayer ? BlackPlayer : WhitePlayer;
        }
    }
}
