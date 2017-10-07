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

            Player joueur1 = new Player("Jojo");
            Player joueur2 = new Player("Gigi");

            game.StartGame();

           

            Console.Read();
        }
    }
}
