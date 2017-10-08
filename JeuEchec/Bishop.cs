using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Bishop : Pieces
    {
        public Bishop(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Bi." + colour;
        }
        public Bishop(Colour colour) : base(colour)
        {
            DisplayName = "Bi." + colour;
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
            int newCoordX;
            int newCoordY;

            //UpLeft
            for (int i = 1; i < 8; i++)
            {
                newCoordX = coord.x + (i * Direction);
                newCoordY = coord.y + (i * Direction);

                //Vérification coords dans les limites du plateau
                if (newCoordX < 8 && newCoordX >= 0
                    && newCoordY < 8 && newCoordY >= 0)
                {
                    CaseDirection = GameBoard[newCoordX, newCoordY];
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
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                }
            }

            //UpRight
            for (int i = 1; i < 8; i++)
            {
                newCoordX = coord.x + (i * Direction);
                newCoordY = coord.y - (i * Direction);

                //Vérification coords dans les limites du plateau
                if (newCoordX < 8 && newCoordX >= 0
                    && newCoordY < 8 && newCoordY >= 0)
                {
                    CaseDirection = GameBoard[newCoordX, newCoordY];
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
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                }
            }

            //DownLeft
            for (int i = 1; i < 8; i++)
            {
                newCoordX = coord.x - (i * Direction);
                newCoordY = coord.y + (i * Direction);

                //Vérification coords dans les limites du plateau
                if (newCoordX < 8 && newCoordX >= 0
                    && newCoordY < 8 && newCoordY >= 0)
                {
                    CaseDirection = GameBoard[newCoordX, newCoordY];
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
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                }
            }

            //DownRight
            for (int i = 1; i < 8; i++)
            {
                newCoordX = coord.x - (i * Direction);
                newCoordY = coord.y - (i * Direction);

                //Vérification coords dans les limites du plateau
                if (newCoordX < 8 && newCoordX >= 0
                    && newCoordY < 8 && newCoordY >= 0)
                {
                    CaseDirection = GameBoard[newCoordX, newCoordY];
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
                else if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                    break;
                }
                else if (CaseDirection == null)
                {
                    coords.Add(new Coord(newCoordX, newCoordY));
                }
            }

            return coords;
        }
    }
}
