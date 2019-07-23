using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectGame myGame = new ConnectGame();

            myGame.Play();
            
        }
    }
}
