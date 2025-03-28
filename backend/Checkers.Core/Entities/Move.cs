using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Core.Entities
{
    public class Move
    {
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }
        public bool IsCapture { get; set; }

        public Move() { }

        public Move(int fromX, int fromY, int toX, int toY, bool isCapture)
        {
            FromX = fromX;
            FromY = fromY;
            ToX = toX;
            ToY = toY;
            IsCapture = isCapture;
        }
    }
}
