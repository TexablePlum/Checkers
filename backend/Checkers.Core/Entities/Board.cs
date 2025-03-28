using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Core.Enums;

namespace Checkers.Core.Entities
{
    public class Board
    {
        public List<Piece> Pieces { get; set; }

        public Board() {
            Pieces = new();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (var i = 0; i < 3; i++)
            {
                var startColumn = (i + 1) % 2;

                for (var j = startColumn; j < 8; j += 2)
                {
                    Pieces.Add(new(PieceColor.Black, i, j));
                }
            }

            for (var i = 5; i < 8; i++)
            {
                var startColumn = (i + 1) % 2;

                for (var j = startColumn; j < 8; j = j + 2)
                {
                    Pieces.Add(new(PieceColor.White, i, j));
                }
            }
        }

        public bool ValidateMove(Move move, PieceColor pieceColor) {

            // TODO: Implement this method !!!
            return true;
        }
    }
}
