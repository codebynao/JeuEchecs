using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuEchec
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Player joueur1 = new Player("Joueur 1");
            Player joueur2 = new Player("Joueur 2");

            game.StartGame();

           

            Console.Read();
        }
    }
}
