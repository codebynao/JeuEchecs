using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Knight : Pieces
    {
        public Knight(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Kn." + colour;
        }
        public Knight(Colour colour) : base(colour)
        {
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


            /*Up Left*/
            newCoordX = coord.x - (2 * Direction);
            newCoordY = coord.y - Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];
                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                else if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }


            /*Up Right*/
            newCoordX = coord.x - (2 * Direction);
            newCoordY = coord.y + Direction;
            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                else if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }



            /*Right Up*/
            newCoordX = coord.x - Direction;
            newCoordY = coord.y + (2 * Direction);

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                else if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }
                

            /*Right Down*/
            newCoordX = coord.x + Direction;
            newCoordY = coord.y + (2 * Direction);

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                else if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }
                

            /*Down Right*/
            newCoordX = coord.x + (2 * Direction);
            newCoordY = coord.y + Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }
                

            /*Down Left*/
            newCoordX = coord.x + (2 * Direction);
            newCoordY = coord.y - Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                else if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }
                

            /*Left Down*/
            newCoordX = coord.x + Direction;
            newCoordY = coord.y - (2 * Direction);

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[newCoordX, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(newCoordX, newCoordY));

                else if (CaseDirection == null)
                    coords.Add(new Coord(newCoordX, newCoordY));
            }
                

            /*Left Up*/
            newCoordX = coord.x - Direction;
            newCoordY = coord.y - (2 * Direction);

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordY >= 0 && newCoordY < 8 && newCoordY >= 0)
            {
                CaseDirection = GameBoard[coord.x, newCoordY];

                //Ajout des coords disponibles
                if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                    coords.Add(new Coord(coord.x, newCoordY));

                else if (CaseDirection == null && newCoordY < 8 && newCoordY >= 0)
                    coords.Add(new Coord(coord.x, newCoordY));
            }
                
            return coords;
        }
    }
}
