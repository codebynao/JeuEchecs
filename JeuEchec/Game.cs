using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Game
    {
        //Variables
        /*private string HorizLine = " --- ";
        private string LeftVertiLine = "| ";
        private string RightVertiLine = " |";*/
        public Pieces[,] GameBoard;
        public Pieces.Colour ColourCurrentPlayer;
        public int lig;
        public int col;

        public void StartGame()
        {
            //nouveau plateau
            GameBoard = new Pieces[8, 8];
            //initialisation du plateau
            FillBoard();
            //affichage du plateau
            PrintBoard();
            //choix du joueur qui commence
            FirstPlayer();
            
            PlayTurn();
        }

        public void PlayTurn()
        {
            Pieces p = AskPieceToPlayer();
            Console.WriteLine("Vous jouez le pion " + GameBoard[lig, col].DisplayName +"["+lig+","+col+"]");
            //TODO demander une piece à un joueur --> AskPieceToPlayer()
            //TODO vérifier son emplacement sur plateau(tableau) --> AskCoordinate()
            //TODO déplacer la pièce --> MovePiece
            //TODO l'autre joueur joue le tour d'après
            //TODO tant qu'aucun des joueurs a perdu (IsGameOver --> true) on recommence

        }

        public void FirstPlayer()
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int NbRandom = rd.Next(0, 2);


            if (NbRandom == 0)
            {
                ColourCurrentPlayer = Pieces.Colour.white;
                Console.WriteLine(Player.ListPlayers[0] + " commence la partie et vous avez les pions " + ColourCurrentPlayer);
            }
            else
            {
                ColourCurrentPlayer = Pieces.Colour.black;
                Console.WriteLine(Player.ListPlayers[1] + " commence la partie et vous avez les pions " + ColourCurrentPlayer);
            }
        }

        public bool IsGameOver()
        {
            return false;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //Console.Write(" ------------ ");
                    if (GameBoard[i, j] != null)
                    {
                        Console.Write("|  " + GameBoard[i, j].DisplayName + "  |");
                    }
                    else
                    {
                        Console.Write("|            |");
                    }
                }
                Console.WriteLine();
            }
        }
        public void ChooseCoordPiece()
        {
            Console.WriteLine("Choisissez un numéro de ligne entre 0 et 7");
            lig = int.Parse(Console.ReadLine());
            Console.WriteLine("Choisissez un numéro de colonne entre 0 et 7");
            col = int.Parse(Console.ReadLine());
        }
        public Pieces AskPieceToPlayer()
        {
            Pieces p = null;
            while (p == null || p.colour != ColourCurrentPlayer)
            {
                Console.WriteLine("Choisissez un numéro de ligne entre 0 et 7");
                lig = int.Parse(Console.ReadLine());
                Console.WriteLine("Choisissez un numéro de colonne entre 0 et 7");
                col = int.Parse(Console.ReadLine());
                p = GameBoard[lig, col];
            }
            return p;
        }

        /*public Pieces AskCoordinateToFindYourPiece()
        {
            //TODO demander les coordonnées en boucle pour trouver la pièce
            //TODO si on trouve la piece --> AskCoordinateIntoAList
            //TODO sinon demander une autre piece au joueur...
            //TODO 
        }

        public Coord AskCoordinateIntoAList(List<Coord> listCoord)
        {
            //TODO Demander des coordonnées et chercher dans la liste si elles existent --> GetPossibleMoves
            //TODO le joueur choisit la case sur laquelle il veut déplacer sa pièce
            //TODO bouger la pièce --> MovePiece
        }*/

        public void MovePiece(Coord CoordPiece, Coord Destination)
        {

        }

        public void FillBoard()
        {
            /*for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        for (int j = 0; j < 8; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                case 7:
                                    GameBoard[i, j] = new Rook(Pieces.Colour.black);
                                    break;
                                case 1:
                                case 6:
                                    GameBoard[i, j] = new Knight(Pieces.Colour.black);
                                    break;
                                case 2:
                                case 5:
                                    GameBoard[i, j] = new Bishop(Pieces.Colour.black);
                                    break;
                                case 3:
                                    GameBoard[i, j] = new Queen(Pieces.Colour.black);
                                    break;
                                case 4:
                                    GameBoard[i, j] = new King(Pieces.Colour.black);
                                    break;
                            }
                        }
                        break;

                    case 1:
                        for (int j = 0; j < 8; j++)
                        {
                            GameBoard[i, j] = new Pawn(Pieces.Colour.black);
                        }
                        break;

                    case 6:
                        for (int j = 0; j < 8; j++)
                        {
                            GameBoard[i, j] = new Pawn(Pieces.Colour.white);
                        }
                        break;

                    case 7:
                        for (int j = 0; j < 8; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                case 7:
                                    GameBoard[i, j] = new Rook(Pieces.Colour.white);
                                    break;
                                case 1:
                                case 6:
                                    GameBoard[i, j] = new Knight(Pieces.Colour.white);
                                    break;
                                case 2:
                                case 5:
                                    GameBoard[i, j] = new Bishop(Pieces.Colour.white);
                                    break;
                                case 3:
                                    GameBoard[i, j] = new Queen(Pieces.Colour.white);
                                    break;
                                case 4:
                                    GameBoard[i, j] = new King(Pieces.Colour.white);
                                    break;
                            }
                        }
                        break;
                }
            }*/
            GameBoard[0, 0] = new Rook(Pieces.Colour.black);
            GameBoard[0, 1] = new Knight(Pieces.Colour.black);
            GameBoard[0, 2] = new Bishop(Pieces.Colour.black);
            GameBoard[0, 3] = new Queen(Pieces.Colour.black);
            GameBoard[0, 4] = new King(Pieces.Colour.black);
            GameBoard[0, 5] = new Bishop(Pieces.Colour.black);
            GameBoard[0, 6] = new Knight(Pieces.Colour.black);
            GameBoard[0, 7] = new Rook(Pieces.Colour.black);

            for (int i = 1; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameBoard[i, j] = new Pawn(Pieces.Colour.black);
                }
            }

            for (int i = 6; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameBoard[i, j] = new Pawn(Pieces.Colour.white);
                }
            }

            GameBoard[7, 0] = new Rook(Pieces.Colour.white);
            GameBoard[7, 1] = new Knight(Pieces.Colour.white);
            GameBoard[7, 2] = new Bishop(Pieces.Colour.white);
            GameBoard[7, 3] = new King(Pieces.Colour.white);
            GameBoard[7, 4] = new Queen(Pieces.Colour.white);
            GameBoard[7, 5] = new Bishop(Pieces.Colour.white);
            GameBoard[7, 6] = new Knight(Pieces.Colour.white);
            GameBoard[7, 7] = new Rook(Pieces.Colour.white);

        }





    }
}

