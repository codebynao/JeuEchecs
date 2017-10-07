using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    abstract class Pieces
    {
        public enum Colour { white, black}
        public Colour colour;
        public Coord coord;

        public string DisplayName;

        public Pieces(Colour colour, Coord coord)
        {
            this.colour = colour;
            this.coord = coord;
        }

        public Pieces(Colour colour)
        {
            this.colour = colour;
        }

        public virtual List<Coord> GetPossibleMoves(Pieces[,] GameBoard, Coord coord)
        {
            return new List<Coord>();
        }
    }
}
