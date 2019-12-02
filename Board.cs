using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    
    public class Board : IBoard
    {
        private readonly IPrint _print;
        private readonly IGameRules _gameRules;
        
        public Board(IPrint print, IGameRules gameRules)
        {
            _print=print;
            _gameRules = gameRules;
        }

        private char[] BoardArray = {'.', '.', '.', '.', '.', '.', '.', '.', '.', '.'};
        
        public char[] GetBoardArray()
        {
            return BoardArray;
        }
        
        public void PrintBoard()
        {
            Console.WriteLine("  {0}    {1}    {2}", BoardArray[1], BoardArray[2], BoardArray[3]);
            Console.WriteLine("  {0}    {1}    {2}", BoardArray[4], BoardArray[5], BoardArray[6]);
            Console.WriteLine("  {0}    {1}    {2}", BoardArray[7], BoardArray[8], BoardArray[9]);
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

        public void CheckIfPositionIsValid(string position)
        {
            if (GetArrayIndex(position) == -1)
            {
                _print.PrintTheMessage("The position coordinate is invalid, try again......");
                _print.PrintTheMessage("\n");
                Thread.Sleep(2000);
            }
        }
        
        public void UpdateBoardArray(char player1, char player2, int roundCounter, int choiceOfPlayer)
        {
            if (choiceOfPlayer == 0)
            {
                roundCounter++;
                _print.PrintTheMessage($"Player {(roundCounter % 2) + 1} has given up for this round");
                _print.PrintTheMessage("\n");
            }

            if (choiceOfPlayer != 0 && BoardArray[choiceOfPlayer] != player1 && BoardArray[choiceOfPlayer] != player2 )
            {
                if (roundCounter % 2 == 0)
                {
                    BoardArray[choiceOfPlayer] = player2;
                }

                else
                {
                    BoardArray[choiceOfPlayer] = player1;
                }
                _print.PrintTheMessage("Move accepted, here's the current board: ");
                _print.PrintTheMessage("\n");
            }
        }
        
        public bool CheckIfPlaceIsTaken(char player1, char player2, int roundCounter, int choiceOfPlayer)
        {
            if (BoardArray[choiceOfPlayer] == player1 && choiceOfPlayer != 0 || BoardArray[choiceOfPlayer] == player2 && choiceOfPlayer != 0)
            {
                _print.PrintTheMessage("Oh no, a piece is already at this place! Try again..");
                _print.PrintTheMessage("\n");
                return true;
            }
            return false;
        }

        public void PrintGameResult(GameResult gameResult,int numberOfRounds)
        {
            if (gameResult == GameResult.Win)
            {
                _print.PrintTheMessage($"Well done Player {numberOfRounds % 2 + 1} won the game!");
            }

            if (gameResult == GameResult.Draw)
            {
                _print.PrintTheMessage("Draw");
            }
        }
    }
}