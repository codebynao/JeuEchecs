﻿using System;
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


            if (colour == Colour.black)
            {
                ColourEnnemy = Colour.white;
                Direction = -1;
            }

            else
            {
                ColourEnnemy = Colour.black;
                Direction = 1;
            }

            Pieces CaseDirection = GameBoard[coord.x, coord.y + Direction];
            Pieces CaseSide1 = GameBoard[coord.x + 1, coord.y + Direction];
            Pieces CaseSide2 = GameBoard[coord.x - 1, coord.y + Direction];


            if (CaseDirection == null && CaseDirection.coord.x < 8 && CaseDirection.coord.y < 8)
                coords.Add(new Coord(coord.x, coord.y + Direction));

            if (CaseSide1 != null && CaseSide1.colour == ColourEnnemy && CaseDirection.coord.x < 8 && CaseDirection.coord.y < 8)
                coords.Add(new Coord(coord.x + 1, coord.y + Direction));

            if (CaseSide2 != null && CaseSide2.colour == ColourEnnemy && CaseDirection.coord.x < 8 && CaseDirection.coord.y < 8)
                coords.Add(new Coord(coord.x - 1, coord.y + Direction));


            return coords;
        }
    }
}
