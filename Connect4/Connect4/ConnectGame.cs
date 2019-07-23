using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4
{
    class ConnectGame
    {
        Board TheBoard;

        enum GameStates
        {
            StartGame,
            Player1Turn,
            Player2Turn,
            Player1Win,
            Player2Win,
            DrawGame,
            PlayAgain,
        };

        GameStates currentState;

        public ConnectGame()
        {
            TheBoard = new Board();

            TheBoard.Initialise();
            currentState = GameStates.StartGame;

        }

        private void Restart()
        {
            TheBoard.Initialise();
        }

        private void Display()
        {
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    switch (TheBoard.board[x, y])
                    {
                            
                        case Board.Player.Empty:
                            //if (y == 0)
                            //    Console.Write(" " + ((y * 3) + x + 1).ToString() + " ");

                            
                                
                            Console.Write(" - ");
                            break;

                        case Board.Player.One:
                            Console.Write(" R ");
                            break;

                        case Board.Player.Two:
                            Console.Write(" Y ");
                            break;

                    }
                }
               Console.WriteLine(); 
            }

            Console.WriteLine();

            for (int y = 0; y < 1; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    switch(TheBoard.column[x,y])
                    {
                        case Board.Player.Empty:
                            Console.Write(" " + (x+1).ToString() + " ");
                                break;
                    }
                }
            }
           
        }

        public void Play()
        {
            bool bQuit = false;

            while (bQuit == false)
            {
                switch (currentState)
                {
                    case GameStates.StartGame:
                        Restart();
                        currentState = GameStates.Player1Turn;
                        break;

                    case GameStates.Player1Turn:
                        {
                            
                            Console.Clear(); //replaces the old board with the updated board
                            Console.WriteLine("\nPlayer one to go");
                            Console.WriteLine();
                            Display();
                            Console.WriteLine();
                            int y = 5;
                            bool complete = false;
                            String go = Console.ReadLine();
                            int val = Convert.ToInt32(go) - 1;

                            try
                            {
                                while (complete == false)
                                {
                                    
                                    if (TheBoard.IsTurnValid(val, y) == true)
                                    {
                                        TheBoard.PlacePiece(Board.Player.One, val, y);

                                        if (TheBoard.IsWon(val, y) == true)
                                        {
                                            currentState = GameStates.Player1Win;
                                            break;
                                        }

                                        else
                                        {
                                            currentState = GameStates.Player2Turn;
                                            break;
                                        }
                                        
                                    }
                                    y--;
                                    
                                }
                                
                            }
                            catch(System.Exception ex)
                            {

                            }
                        }
                        break;
                        
                    case GameStates.Player2Turn:
                        {
                            Console.Clear();
                            Console.WriteLine("\nPlayer two to go");
                            Console.WriteLine();
                            Display();
                            Console.WriteLine();
                            int y = 5;
                            bool complete = false;
                            String go = Console.ReadLine();
                            int val = Convert.ToInt32(go) - 1;

                            try
                            {
                                while (complete == false)
                                {

                                    if (TheBoard.IsTurnValid(val, y) == true)
                                    {
                                        TheBoard.PlacePiece(Board.Player.Two, val, y);

                                        if (TheBoard.IsWon(val, y) == true)
                                        {
                                            currentState = GameStates.Player2Win;
                                            break;
                                        }

                                        else
                                        {
                                            currentState = GameStates.Player1Turn;
                                            break;
                                        }

                                    }
                                        y--;
                                        
                                    
                                
                                }
                            }
                            catch (System.Exception ex)
                            {

                            }
                        }
                        break;

                    case GameStates.Player1Win:
                        {
                            Console.Clear();
                            Console.WriteLine("Player 1 wins!");
                            Display();

                            currentState = GameStates.PlayAgain;

                        }
                        break;

                    case GameStates.Player2Win:
                        {
                            Console.Clear();
                            Console.WriteLine("Player 2 wins!");
                            Display();

                            currentState = GameStates.PlayAgain;

                        }
                        break;

                    case GameStates.PlayAgain:
                        {
                            Console.Write("Play again [y/n]");
                            ConsoleKeyInfo c = Console.ReadKey();

                            if (c.Key != ConsoleKey.Y)
                            {
                                bQuit = true; //terminates game
                            }
                            else
                            {
                                currentState = GameStates.StartGame;
                            }
                        }
                        break;

                    default:
                        throw new Exception();
                }
            }

        }



    }
}
