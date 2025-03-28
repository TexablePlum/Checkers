using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Core.Enums;

namespace Checkers.Core.Entities
{
    public class Piece
    {
        public PieceColor Color {get; set;}
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsKing { get; set; }

        public Piece() { }

        public Piece(PieceColor color, int x, int y) {
            Color = color;
            X = x;
            Y = y;
            IsKing = false;
        }
    }
}
