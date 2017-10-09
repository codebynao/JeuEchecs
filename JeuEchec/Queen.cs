using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Queen : Pieces
    {
        //Constructeurs
        public Queen(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Qu." + colour;
        }
        public Queen(Colour colour) : base(colour)
        {
        }

        //Methode
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

            /*Up Left*/
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


            /*Up Right*/
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


            /*Down Left*/
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


            /*Down Right*/
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

            int newCoord;


            /*Up*/
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
            

            /*Down*/
            for (int i = 1; i < 8; i++)
            {
                newCoord = coord.x - (i * Direction);
                //Vérification coords dans les limites du plateau
                if (newCoord < 8 && newCoord >= 0)
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


            /*Right*/
            for (int i = 1; i < 8; i++)
            {
                newCoord = coord.y - (i * Direction);
                //Vérification coords dans les limites du plateau
                if (newCoord < 8 && newCoord >= 0)
                    CaseDirection = GameBoard[coord.x, newCoord];

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
                else if (CaseDirection == null && newCoord < 8 && newCoord >= 0)
                {
                    coords.Add(new Coord(coord.x, newCoord));
                }
            }

            /*Left*/
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
                else if (CaseDirection == null && newCoord < 8 && newCoord >= 0)
                {
                    coords.Add(new Coord(coord.x, newCoord));
                }
            }

            return coords;
        }


    }
}
