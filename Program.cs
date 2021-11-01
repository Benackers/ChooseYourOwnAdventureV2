using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventureV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game _Game = new Game();
            while (_Game.isRunning)
            {
                _Game.Update();
            }
        }
    }
}