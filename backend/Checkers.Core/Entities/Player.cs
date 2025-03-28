using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Core.Enums;

namespace Checkers.Core.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public PieceColor Color { get; set; }

        public Player() { }

        public Player(string name, PieceColor color)
        {
            Name = name;
            Color = color;
        }
    }
}
