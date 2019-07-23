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
            board = new Player[7, 6]; //board size  [x,y] 
            column = new Player[7, 1];
        }

        
        public void Initialise()//makes the board to play on
        {
            for (int y = 0; y < 6; y++)
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
            if(y + 3 >= 6)
            {
                return false;
            }

            if (board[x, y] == ePlayer && board[x, y + 1] == ePlayer && board[x, y + 2] == ePlayer && board[x, y + 3] == ePlayer)
                return true;

            return true;
        }

        private bool horizontalTest(Player ePlayer, int x, int y)
        {
            int startX = x++;

            if (x + 3 >= 7)
                return false;

            while (board[startX, y] == board[x, y])
            {
                startX--;
                if (board[startX, y] == ePlayer && board[startX + 1, y] == ePlayer && board[startX + 2, y] == ePlayer && board[startX + 3, y] == ePlayer)
                    return true;
                else
                    return true;

            }

            return false;
        }

        private bool testTopLeftToBottomRight(Player ePlayer, int x, int y)
        {
            if (y + 3 >= 6)
                return false;

            if (x + 3 >= 7)
                return false;
            int startX = x++;
            int startY = y++;
            while (board[startX, startY] == board[x, y])
            {
                startX--;
                startY--;
                if (board[startX, startY] == ePlayer && board[startX + 1, startY - 1] == ePlayer
                    && board[startX + 2, startY - 2] == ePlayer && board[startX + 3, startY - 3] == ePlayer)
                    return true;
            }
            return true;
        }

        private bool testBottomLeftToTopRight(Player ePlayer, int x, int y)
        {
            if(y + 3 >= 6)
                return false;

            if(x + 3 >= 7)
                return false;

            int startX = x++;
            int startY = y++;
            while (board[startX, startY] == board[x, y])
            {
                startX--;
                startY--;
                if (board[startX, startY] == ePlayer && board[startX + 1, startY + 1] == ePlayer
                    && board[startX + 2, startY + 2] == ePlayer && board[startX + 3, startY + 3] == ePlayer)
                    return true;
            }
            return true;
        }

        public bool IsWon(Player ePlayer, int x, int y)
        {
            //if ((board[0 + 4, 0] == ePlayer)) return true;

            //return false;
            //Vertical Test
            if(verticalTest(ePlayer, x, y) == true)
                return true;

            //Horizontal Test
            if (horizontalTest(ePlayer, x, y) == true)
                return true;

            //testTopLeftToBottonRightLineOfFour(x, y)
            if (testTopLeftToBottomRight(ePlayer, x, y) == true)
                return true;

            //testBottomLeftToTopRightLineOfFour
            if (testBottomLeftToTopRight(ePlayer, x, y) == true)
                return true;

            return true;//needs to be changed

            //if (horizontalTest(ePlayer, x, y)) ;
            //    return true;
            //Horizontal Test
            //int startX = x;
            //while(board[startX,y] == board[x, y])
            //{
            //    startX--;
            //    if (board[startX, y] == ePlayer && board[startX + 1, y] == ePlayer && board[startX + 2, y] == ePlayer && board[startX + 3, y] == ePlayer)
            //        return true;
            //    else
            //        return false;


            //}
            ////testTopLeftToBottonRightLineOfFour(x, y)
            //int startX2 = x;
            //int startY = y;
            //while (board[startX, startY] == board[x, y])
            //{
            //    startX2--;
            //    startY--;
            //    if (board[startX2, startY] == ePlayer && board[startX2 + 1, startY + 1] == ePlayer && board[startX2 + 2, startY + 2] == ePlayer && board[startX2 + 3, startY + 3] == ePlayer)
            //    {
            //        return true;
            //    }
            //}
        }

        public bool IsWon(int x, int y)
        {
            
            return IsWon(Player.One, x, y) || IsWon(Player.Two, x, y);
            //needs to be changed
        }

        public bool IsTurnValid(int x, int y)
        {

            if (x < 7 || y < 6)
                return (board[x, y] == Player.Empty);
            //if 
            //    return true;

            
                return true;
 
        }
    }
}
