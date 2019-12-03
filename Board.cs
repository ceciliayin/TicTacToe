using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    public class Board : IBoard
    {
        private readonly IPrint _print;
        
        public Board(IPrint print)
        {
            _print=print;
        }

        private char[] _boardArray = {'.', '.', '.', '.', '.', '.', '.', '.', '.', '.'};
        
        public char[] GetBoardArray()
        {
            return _boardArray;
        }
        
        public void PrintBoard()
        {
            Console.WriteLine("  {0}    {1}    {2}", _boardArray[1], _boardArray[2], _boardArray[3]);
            Console.WriteLine("  {0}    {1}    {2}", _boardArray[4], _boardArray[5], _boardArray[6]);
            Console.WriteLine("  {0}    {1}    {2}", _boardArray[7], _boardArray[8], _boardArray[9]);
        }
        
        public int GetArrayIndex(string position)
        {
            var coordinatesStrings = new string[11] {"0,0", "1,1", "1,2", "1,3", "2,1", "2,2", "2,3", "3,1", "3,2", "3,3", "q"};
            for (int i = 1; i < 10; i++)
            {
                if (position == coordinatesStrings[i])
                {
                    return i;
                }
            }

            if (position == coordinatesStrings[10])
            {
                return 0;
            }
            
            return -1;
        }

        public void CheckIfPositionIsValid(string position,Player currentPlayer)
        {
            if (GetArrayIndex(position) == -1)
            {
                _print.PrintTheMessage("The position coordinate is invalid, try again......");
                _print.PrintTheMessage("\n");
                Thread.Sleep(2000);
            }
        }
        
        public void UpdateBoardArray(int choiceOfPlayer,Player currentPlayer)
        {
            if (choiceOfPlayer == 0)
            {
                if (currentPlayer == Player.X)
                {
                    _print.PrintTheMessage("Player 1 has given up for this round");
                    _print.PrintTheMessage("\n");
                    currentPlayer = Player.O;
                }
                else
                {
                    _print.PrintTheMessage("Player 2 has given up for this round");
                    _print.PrintTheMessage("\n");
                    currentPlayer = Player.X;
                }
            }

            if (choiceOfPlayer != 0 && _boardArray[choiceOfPlayer] != 'X' && _boardArray[choiceOfPlayer] != 'O' )
            {
                if (currentPlayer==Player.O)
                {
                    _boardArray[choiceOfPlayer] = 'O';
                }

                else
                {
                    _boardArray[choiceOfPlayer] = 'X';
                }
                _print.PrintTheMessage("Move accepted, here's the current board: ");
                _print.PrintTheMessage("\n");
            }
        }
        
        public bool CheckIfPlaceIsTaken(int choiceOfPlayer)
        {
            if (_boardArray[choiceOfPlayer] == 'X' && choiceOfPlayer != 0 || _boardArray[choiceOfPlayer] == 'O' && choiceOfPlayer != 0)
            {
                _print.PrintTheMessage("Oh no, a piece is already at this place! Try again..");
                _print.PrintTheMessage("\n");
                return true;
            }
            return false;
        }
    }
}