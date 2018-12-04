using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceBattleEngine; // Reference the namespace in the other assembly

namespace SpaceBattleSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            myGame.Start();
        }
    }
}
