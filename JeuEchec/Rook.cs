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
                Direction = 1;
            }

            else
            {
                ColourEnnemy = Colour.black;
                Direction = -1;
            }

            //initialisation 
            Pieces CaseDirection = null;
            int newCoord;

            //Up
            for (int i = 1; i < 8; i++)
            {
                newCoord = coord.x + (i * Direction);
                //Vérification coords dans les limites du plateau
                if (newCoord < 8 && newCoord >= 0)
                {
                    CaseDirection = GameBoard[newCoord, coord.y];
                }
                else
                {
                    break;
                }

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour != ColourEnnemy)
                {
                    break;
                }
                else if(CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(newCoord, coord.y));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(newCoord, coord.y));
                }
            }

            //Down
            for (int i = 1; i < 8; i++)
            {
                newCoord = coord.x - (i * Direction);
                //Vérification coords dans les limites du plateau
                if (newCoord < 8 && newCoord >=0)
                    CaseDirection = GameBoard[newCoord, coord.y];
                else
                {
                    break;
                }

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour != ColourEnnemy)
                {
                    break;
                }
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(newCoord, coord.y));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(newCoord, coord.y));
                }
            }

            //Right
            for (int i = 1; i < 8; i++)
            {
                newCoord = coord.y - (i * Direction);
                //Vérification coords dans les limites du plateau
                if (newCoord < 8 && newCoord >= 0)
                    CaseDirection = GameBoard[coord.x,newCoord];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour != ColourEnnemy)
                {
                    break;
                }
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(coord.x, newCoord));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(coord.x, newCoord));
                }
            }

            //Left
            for (int i = 1; i < 8; i++)
            {
                newCoord = coord.y + (i * Direction);
                //Vérification coords dans les limites du plateau
                if (newCoord < 8 && newCoord >= 0)
                    CaseDirection = GameBoard[coord.x, newCoord];
                else
                {
                    break;
                }

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour != ColourEnnemy)
                {
                    break;
                }
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(coord.x, newCoord));
                    break;
                }
                else if (CaseDirection == null/* && (coord.y - i * Direction) < 8 && (coord.y + i * Direction) >= 0*/)
                {
                    coords.Add(new Coord(coord.x, newCoord));
                }
            }



            /*//initialisation 
            Pieces CaseDirection = null;
            int i = 1;

            //Sides
            for (i = 1; i < 8; i++)
            {
                i *= Direction;
                if(coord.y+i >= 0 && coord.y+i < 8)
                    CaseDirection = GameBoard[coord.x, coord.y+i];

                if (CaseDirection == null || (CaseDirection != null && CaseDirection.colour == ColourEnnemy))
                    coords.Add(new Coord(coord.x, coord.y+i));
            }

            //Up and down
            while(i <= 7)
            {
                i *= Direction;
                if (coord.x + i >= 0 && coord.x + i < 8)
                    CaseDirection = GameBoard[coord.x + i, coord.y];

                if (CaseDirection == null || (CaseDirection != null && CaseDirection.colour == ColourEnnemy))
                    coords.Add(new Coord(coord.x + i, coord.y));
            }*/

            return coords;
        }
    }
}
