using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class King : Pieces
    {
        public King(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Ki." + colour;
        }
        public King(Colour colour) : base(colour)
        {
            DisplayName = "Ki." + colour;
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
                Direction = 1;
            }

            else
            {
                ColourEnnemy = Colour.black;
                Direction = -1;
            }

            //initialisation 
            Pieces CaseDirection = null;
            Pieces CaseSide1 = null;
            Pieces CaseSide2 = null;

            //Vérification coords dans les limites du plateau
            if (coord.x + Direction < 8)
                CaseDirection = GameBoard[coord.x + Direction, coord.y];

            if (coord.x + Direction < 8 && coord.y + 1 < 8)
                CaseSide1 = GameBoard[coord.x + Direction, coord.y + 1];

            if (coord.x + Direction < 8 && coord.y - 1 >= 0)
                CaseSide2 = GameBoard[coord.x + Direction, coord.y - 1];

            //Ajout des coords disponibles
            if (CaseDirection == null)
                coords.Add(new Coord(coord.x + Direction, coord.y));

            if (CaseSide1 != null && CaseSide1.colour == ColourEnnemy)
                coords.Add(new Coord(coord.x + Direction, coord.y + 1));

            if (CaseSide2 != null && CaseSide2.colour == ColourEnnemy)
                coords.Add(new Coord(coord.x + Direction, coord.y - 1));


            return coords;
        }
    }
}
