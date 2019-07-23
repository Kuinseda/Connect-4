using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4
{
    class Board
    {
        public enum Player
        {
            One,
            Two,
            Empty,

        };
        public Player[,] board;
        public Player[,] column;

        public Board()
        {
            board = new Player[7, 7]; //board size  [x,y] 
            column = new Player[7, 1];//chosable column
        }

        
        public void Initialise()//makes the board to play on
        {
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    //if(y != 0)
                        board[x, y] = Player.Empty;
                }
            }
            for(int y = 0; y < 1; y++)
            {
                for(int x = 0; x < 7; x++)
                {
                    column[x, y] = Player.Empty;
                }
            }
            
            
        }

        public void PlacePiece(Player ePlayer, int x, int y)
        {
                board[x, y] = ePlayer;
        }

        private bool verticalTest(Player ePlayer, int x, int y)
        {
            if (y + 3 >= 6)
            {
                return false;
            }

            for (int dist = 0; dist < 4; dist++)
            {
                if (board[x, y + dist] != ePlayer)
                {
                    return false;
                }
            }

            return true;
            //if(y + 3 >= 6) // bad code
            //{
            //    return false;
            //}

            //if (board[x, y] == ePlayer && board[x, y + 1] == ePlayer 
            //    && board[x, y + 2] == ePlayer && board[x, y + 3] == ePlayer)
            //    return true;
            //else
            //return false;
            
        }

        private bool horizontalTest(Player ePlayer, int x, int y)
        {
            if (x + 3 >= 7)
            {
                return false;
            }

            for (int distance = 0; distance < 4; distance++)
            {
                if (board[x + distance, y] != ePlayer)
                {
                    return false;
                }
            }

            return true;
            
            //int startX = x; //bad code

            //if (x + 3 >= 7)
            //    return false;
            //if (x - 3 <= 0)
            //    return false;
            //while (board[startX, y] == ePlayer)//board[x, y])//same thing
            //{
                

            //    if (board[x, y] == ePlayer && board[x + 1, y] == ePlayer 
            //        && board[x + 2, y] == ePlayer && board[x + 3, y] == ePlayer ||

            //        board[x, y] == ePlayer && board[x - 1, y] == ePlayer
            //        && board[x - 2, y] == ePlayer && board[x - 3, y] == ePlayer)
            //        return true;
                
            //        startX--;
                
            //    return false;
                
            //}
                
            //return false;

            
        }

        private bool testTopLeftToBottomRight(Player ePlayer, int x, int y)
        {
            if (y + 3 >= 6)
                return false;

            if (x + 3 >= 7)
                return false;
            
            for (int distance = 0; distance < 4; distance++)
            {
                if (board[x + distance, y + distance] != ePlayer)
                {
                    return false;
                }
            }

            return true;
            //int startX = x+1; // bad code
            //int startY = y+1;
            //while (board[startX, startY] == board[x, y])
            //{
            //    startX--;
            //    startY--;
            //    if (board[startX, startY] == ePlayer && board[startX + 1, startY + 1] == ePlayer
            //        && board[startX + 2, startY + 2] == ePlayer && board[startX + 3, startY + 3] == ePlayer ||
            //        board[startX, startY] == ePlayer && board[startX - 1, startY - 1] == ePlayer
            //        && board[startX - 2, startY - 2] == ePlayer && board[startX - 3, startY - 3] == ePlayer)
            //        return true;
            //    else
            //        return false;
            //}
            //return false;

            
        }

        private bool testBottomLeftToTopRight(Player ePlayer, int x, int y)
        {
            if (y - 3 < 0)
                return false;
            
            if (x + 3 >= 7)
                return false;
         
            for (int distance = 0; distance < 4; distance++)
            {
                if (board[x + distance, y - distance] != ePlayer) 
                {
                     return false; 
                }
            }
            
            return true;
       
            //int startX = x++; //bad code
            //int startY = y++;
            //while (board[startX, startY] == board[x, y])
            //{
            //    startX--;
            //    startY--;
            //    if (board[startX, startY] == ePlayer && board[startX + 1, startY - 1] == ePlayer
            //        && board[startX + 2, startY - 2] == ePlayer && board[startX + 3, startY - 3] == ePlayer)
            //        return true;
            //}
            //return false;
            

        }

        public bool IsWon(Player ePlayer, int x, int y)
        {
            for (int c = 0; c < 6; c++)
            {
                for (int p = 0; p < 7; p++)
                {
                    //Vertical Test
                    if (verticalTest(ePlayer, p, c) == true)
                        return true;
                    //Horizontal Test
                    if (horizontalTest(ePlayer, p, c) == true)
                        return true;

                    //diagonal tests
                    if (testTopLeftToBottomRight(ePlayer, p, c) == true)
                        return true;
                    if (testBottomLeftToTopRight(ePlayer, p, c) == true)
                        return true;
                }
            }
            return false;
        }

        public bool IsWon(int x, int y)
        {

            return IsWon(Player.One, x, y) || IsWon(Player.Two, x, y);
      
        }

        public bool IsTurnValid(int x, int y)
        {
            if (board[x, y] == Player.Empty)
                return true;

           
                return false;
        }
    }
}
