using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Rook : Pieces
    {
        public Rook(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Ro." + colour;
        }
        public Rook(Colour colour) : base(colour)
        {
            DisplayName = "Ro." + colour;
        }

        public override List<Coord> GetPossibleMoves(Pieces[,] GameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();
            Colour ColourEnnemy;
            int Direction;

            //direction des pions
            if (colour == Colour.black)
            {
                ColourEnnemy = Colour.white;
            }

            else
            {
                ColourEnnemy = Colour.black;
            }

            //initialisation 
            Pieces CaseDirection = null;
            Pieces CaseOppositeDirection = null;
            Pieces CaseSide1 = null;
            Pieces CaseSide2 = null;

            //Vérification coords dans les limites du plateau
           

            return coords;
        }
    }
}
