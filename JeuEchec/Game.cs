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
        public Pieces[,] GameBoard;
        public Pieces.Colour ColourCurrentPlayer;
        public int lig;
        public int col;
        public Pieces pieceCurrentPlayer;
        public List<Coord> possibleCoordsPiece;
        private int index;
        private int choice;


        public void StartGame()
        {
            //nouveau plateau
            GameBoard = new Pieces[8, 8];

            //initialisation du plateau
            FillBoard();

            //affichage du plateau
            PrintBoard();
            Console.BackgroundColor = ConsoleColor.Black;

            //choix du joueur qui commence
            FirstPlayer();

            //Début de la partie
            PlayTurn();
        }

        public void PlayTurn()
        {
            Console.WriteLine("C'est au tour des pions " + ColourCurrentPlayer);

            //Le joueur choisit un pion
            pieceCurrentPlayer = AskPieceToPlayer();
            Console.WriteLine("Vous jouez le pion " + GameBoard[lig, col].DisplayName + "[" + lig + "," + col + "]\n");

            //Récupération de la liste des déplacements possibles
            possibleCoordsPiece = GetCurrentPiecePossibleMoves();

            //Le joueur choisit son déplacement
            ChooseCoords();

            //Déplacement du pion
            MovePiece();

            //Changement de joueur
            if (ColourCurrentPlayer == Pieces.Colour.white)
            {
                ColourCurrentPlayer = Pieces.Colour.black;
            }
            else
            {
                ColourCurrentPlayer = Pieces.Colour.white;
            }

            //Fin de partie si Roi mangé
            IsGameOver();
        }

        //Remplissage du plateau
        public void FillBoard()
        {
            for (int i = 0; i < 8; i++)
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
                                    GameBoard[i, j] = new Rook(Pieces.Colour.black, new Coord(i, j));
                                    break;
                                case 1:
                                case 6:
                                    GameBoard[i, j] = new Knight(Pieces.Colour.black, new Coord(i, j));
                                    break;
                                case 2:
                                case 5:
                                    GameBoard[i, j] = new Bishop(Pieces.Colour.black, new Coord(i, j));
                                    break;
                                case 3:
                                    GameBoard[i, j] = new Queen(Pieces.Colour.black, new Coord(i, j));
                                    break;
                                case 4:
                                    GameBoard[i, j] = new King(Pieces.Colour.black, new Coord(i, j));
                                    break;
                            }
                        }
                        break;

                    case 1:
                        for (int j = 0; j < 8; j++)
                        {
                            GameBoard[i, j] = new Pawn(Pieces.Colour.black, new Coord(i, j));
                        }
                        break;

                    case 6:
                        for (int j = 0; j < 8; j++)
                        {
                            GameBoard[i, j] = new Pawn(Pieces.Colour.white, new Coord(i, j));
                        }
                        break;

                    case 7:
                        for (int j = 0; j < 8; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                case 7:
                                    GameBoard[i, j] = new Rook(Pieces.Colour.white, new Coord(i, j));
                                    break;
                                case 1:
                                case 6:
                                    GameBoard[i, j] = new Knight(Pieces.Colour.white, new Coord(i, j));
                                    break;
                                case 2:
                                case 5:
                                    GameBoard[i, j] = new Bishop(Pieces.Colour.white, new Coord(i, j));
                                    break;
                                case 3:
                                    GameBoard[i, j] = new Queen(Pieces.Colour.white, new Coord(i, j));
                                    break;
                                case 4:
                                    GameBoard[i, j] = new King(Pieces.Colour.white, new Coord(i, j));
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        //Affichage du plateau et des pions
        public void PrintBoard()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("          0             1             2             3             4             5             6             7");

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //Affichage damier
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else if (i % 2 == 1 && j % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    //Affichage cases pions
                    if (GameBoard[i, j] != null)
                    {
                        if (j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + i);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" |  " + GameBoard[i, j].DisplayName + "  |");
                        }

                        else
                        {
                            Console.Write("|  " + GameBoard[i, j].DisplayName + "  |");
                        }
                    }

                    //Affichage cases vides
                    else
                    {
                        if (j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + i);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" |            |");
                        }
                        else
                        {
                            Console.Write("|            |");
                        }

                    }                  
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        //Choix du premier joueur
        public void FirstPlayer()
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int NbRandom = rd.Next(0, 2);

            //On attribue les pions blancs au joueur qui commence la partie
            if (NbRandom == 0)
            {
                ColourCurrentPlayer = Pieces.Colour.white;
                Console.WriteLine(Player.ListPlayers[0] + " commence la partie.");
            }
            else
            {
                ColourCurrentPlayer = Pieces.Colour.white;
                Console.WriteLine(Player.ListPlayers[1] + " commence la partie.");
            }
        }

        //Demande un pion au joueur en choisissant ses coordonnées
        public Pieces AskPieceToPlayer()
        {
            Pieces p = null;

            while (p == null || p.colour != ColourCurrentPlayer)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Choisissez un numéro de ligne entre 0 et 7");
                Console.ForegroundColor = ConsoleColor.White;
                lig = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Choisissez un numéro de colonne entre 0 et 7");
                Console.ForegroundColor = ConsoleColor.White;
                col = int.Parse(Console.ReadLine());
                p = GameBoard[lig, col];
            }
            return p;
        }

        //Récupération de la liste des mouvements possibles en fonction du pion choisi
        public List<Coord> GetCurrentPiecePossibleMoves()
        {
            possibleCoordsPiece = pieceCurrentPlayer.GetPossibleMoves(GameBoard, pieceCurrentPlayer.coord);
            return possibleCoordsPiece;
        }

        //Affichage sur le plateau des déplacements possibles
        public void ShowPossibleMovesOnBoard()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("          0             1             2             3             4             5             6             7");

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {                   
                    //Affichage damier
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else if (i % 2 == 1 && j % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    //Affichage cases déplacements possibles
                    for (int k = 0; k < possibleCoordsPiece.Count; k++)
                    {
                        if (possibleCoordsPiece[k].x == i && possibleCoordsPiece[k].y == j)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        }
                    }

                    //Affichage cases pions
                    if (GameBoard[i, j] != null)
                    {
                        if (j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + i);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" |  " + GameBoard[i, j].DisplayName + "  |");
                        }

                        else
                        {
                            Console.Write("|  " + GameBoard[i, j].DisplayName + "  |");
                        }
                    }

                    //Affichage cases vides
                    else
                    {
                        if (j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + i);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" |            |");
                        }
                        else
                        {
                            Console.Write("|            |");
                        }

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        //Demande un déplacement au joueur dans la liste des mouvements possibles
        public void ChooseCoords()
    {
            //Affichage possibilité movements sur plateau
            Console.Clear();
            ShowPossibleMovesOnBoard();
        index = 0;
        if (possibleCoordsPiece.Count > 0)
        {
            Console.WriteLine("Veuillez choisir des coordonnées de déplacement : ");
            for (int i = 0; i < possibleCoordsPiece.Count; i++)
            {
                Console.WriteLine(index + " - [" + possibleCoordsPiece[i].x + "," + possibleCoordsPiece[i].y + "]");
                index += 1;
            }
                //Choix additionnel
                index += 1;
                Console.WriteLine(index + " - Changer de pion");

                //On enregistre le choix du joueur et on le convertit en int
                choice = int.Parse(Console.ReadLine());

                //Retour en arrière pour changer de pion
                if(choice == index)
                {
                    Console.Clear();
                    PrintBoard();
                    PlayTurn();
                }
        }
        else
        {
            Console.WriteLine("Aucun déplacement n'est possible.");
            pieceCurrentPlayer = AskPieceToPlayer();
            possibleCoordsPiece = GetCurrentPiecePossibleMoves();
            ChooseCoords();
        }

    }

        //Déplacement du pion
        public void MovePiece()
    {
        int oldCoordX = pieceCurrentPlayer.coord.x;
        int oldCoordY = pieceCurrentPlayer.coord.y;
        for (int i = 0; i < possibleCoordsPiece.Count; i++)
        {
            if (i == choice)
            {
                //On remplace les coordonnées du pion
                pieceCurrentPlayer.coord.x = possibleCoordsPiece[i].x;
                pieceCurrentPlayer.coord.y = possibleCoordsPiece[i].y;
                
                //On vide l'ancienne case du pion
                GameBoard[oldCoordX, oldCoordY] = null;
                
                if (GameBoard[pieceCurrentPlayer.coord.x, pieceCurrentPlayer.coord.y] != null)
                {
                    GameBoard[pieceCurrentPlayer.coord.x, pieceCurrentPlayer.coord.y] = null;
                    GameBoard[pieceCurrentPlayer.coord.x, pieceCurrentPlayer.coord.y] = pieceCurrentPlayer;
                }
                else
                {
                    GameBoard[pieceCurrentPlayer.coord.x, pieceCurrentPlayer.coord.y] = pieceCurrentPlayer;
                }

            }
            
        }
        Console.Clear();
        PrintBoard();
    }

        //Récupération des coordonnées des Rois
        public void IsGameOver()
    {
        Pieces KingWhite = null;
        Pieces KingBlack = null;

        //On cherche les coordonnées des 2 rois sur le plateau
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (GameBoard[i, j] != null && GameBoard[i, j].DisplayName == "Ki." + GameBoard[i, j].colour && GameBoard[i, j].colour == Pieces.Colour.white)
                {
                    KingWhite = GameBoard[i, j];
                }


                else if (GameBoard[i, j] != null && GameBoard[i, j].DisplayName == "Ki." + GameBoard[i, j].colour && GameBoard[i, j].colour == Pieces.Colour.black)
                {
                    KingBlack = GameBoard[i, j];
                }
            }
        }

        //Si un des 2 rois n'existent plus on arrête la partie
        if (KingWhite == null || KingBlack == null)
            if (ColourCurrentPlayer == Pieces.Colour.black)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Les Blancs gagnent la partie.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Les Noirs gagnent la partie.");
            }
        else
            PlayTurn();
    }
    }
}