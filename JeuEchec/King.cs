using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class King : Pieces
    {
        //Constructeurs
        public King(Colour colour, Coord coord) : base(colour, coord)
        {
            DisplayName = "Ki." + colour;
        }
        public King(Colour colour) : base(colour)
        {
        }

        //Methodes
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

            
            /*UpLeft*/
            newCoordX = coord.x + Direction;
            newCoordY = coord.y + Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
                CaseDirection = GameBoard[newCoordX, newCoordY];
                
            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(newCoordX, newCoordY));

            else if (CaseDirection == null)
                coords.Add(new Coord(newCoordX, newCoordY));


            /*Up*/
            newCoordX = coord.x + Direction;
            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0)
                CaseDirection = GameBoard[newCoordX, coord.y];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(newCoordX, coord.y));

            else if (CaseDirection == null)
                coords.Add(new Coord(newCoordX, coord.y));
            
            
            /*UpRight*/
            newCoordX = coord.x + Direction;
            newCoordY = coord.y - Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
                CaseDirection = GameBoard[newCoordX, newCoordY];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(newCoordX, newCoordY));

            else if (CaseDirection == null)
                coords.Add(new Coord(newCoordX, newCoordY));


            /*Right*/
            newCoordY = coord.y - Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordY < 8 && newCoordY >= 0)
                CaseDirection = GameBoard[coord.x, newCoordY];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(coord.x, newCoordY));

            else if (CaseDirection == null && newCoordY < 8 && newCoordY >= 0)
                coords.Add(new Coord(coord.x, newCoordY));


            /*DownRight*/
            newCoordX = coord.x - Direction;
            newCoordY = coord.y - Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
                CaseDirection = GameBoard[newCoordX, newCoordY];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(newCoordX, newCoordY));

            if (CaseDirection == null)
                coords.Add(new Coord(newCoordX, newCoordY));


            /*Down*/
            newCoordX = coord.x - Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0)
                CaseDirection = GameBoard[newCoordX, coord.y];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(newCoordX, coord.y));

            else if (CaseDirection == null)
                coords.Add(new Coord(newCoordX, coord.y));


            /*DownLeft*/
            newCoordX = coord.x - Direction;
            newCoordY = coord.y + Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordX < 8 && newCoordX >= 0 && newCoordY < 8 && newCoordY >= 0)
               CaseDirection = GameBoard[newCoordX, newCoordY];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(newCoordX, newCoordY));

            else if (CaseDirection == null)
                coords.Add(new Coord(newCoordX, newCoordY));


            /*Left*/
            newCoordY = coord.y + Direction;

            //Vérification coords dans les limites du plateau
            if (newCoordY < 8 && newCoordY >= 0)
                CaseDirection = GameBoard[coord.x, newCoordY];

            //Ajout des coords disponibles
            if (CaseDirection != null && CaseDirection.colour == ColourEnnemy)
                coords.Add(new Coord(coord.x, newCoordY));

            else if (CaseDirection == null && newCoordY < 8 && newCoordY >= 0)
                coords.Add(new Coord(coord.x, newCoordY));

            return coords;
        }
    }
}
