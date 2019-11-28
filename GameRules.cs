using System;

namespace Tic_Tac_Toe
{
    public interface IGameRules
    {
        int CheckIfThePlayerWin(char player1, char player2, char[] boardArray);
        void CheckIfConditionIsWinning(int result, int roundCounter);
    }

    public class GameRules : IGameRules
    {
        private readonly IPrint _print;
        
        public GameRules()
        {
            _print=new Print();
        }

        public int CheckIfThePlayerWin(char player1, char player2, char[] boardArray)
        {    
            //check the horizontal condition
            int i = 1;
            for (i = 1; i < 8; i += 3)
            {
                if (boardArray[i] == player1 && boardArray[i + 1] == player1 && boardArray[i + 2] == player1 ||
                    boardArray[i] == player2 && boardArray[i + 1] == player2 && boardArray[i + 2] == player2)
                {
                    return 1;
                }
            }

            //check the vertical condition
            for (i = 1; i < 4; i++)
            {
                if (boardArray[i] == player1 && boardArray[i + 3] == player1 && boardArray[i + 6] == player1 ||
                    boardArray[i] == player2 && boardArray[i + 3] == player2 && boardArray[i + 6] == player2)
                {
                    return 1;
                }
            }

            //check diagonal condition
            for (i = 1; i < 2; i++)
            {
                if (boardArray[i] == player1 && boardArray[i + 4] == player1 && boardArray[i + 8] == player1 ||
                    boardArray[i] == player2 && boardArray[i + 4] == player2 && boardArray[i + 8] == player2)
                    return 1;

            }

            for (i = 3; i < 4; i++)
            {
                if (boardArray[i] == player2 && boardArray[i + 2] == player2 && boardArray[i + 4] == player2 ||
                    boardArray[i] == player1 && boardArray[i + 2] == player1 && boardArray[i + 4] == player1)
                    return 1;
            }

            //check if it's a draw
            if (boardArray[1] != '.' && boardArray[2] != '.' && boardArray[3] != '.' && boardArray[4] != '.' &&
                boardArray[5] != '.' && boardArray[6] != '.' && boardArray[7] != '.' && boardArray[8] != '.' &&
                boardArray[9] != '.')
            {
                return -1;
            }
        
            return 0; 
        }
    
        public void CheckIfConditionIsWinning(int result, int roundCounter)
        {
            if (result == 1)
            {
                _print.PrintTheMessage($"Well done Player {roundCounter % 2 + 1} won the game!");
            }

            if (result == -1)
            {
                _print.PrintTheMessage("Draw");
            }
        }
    }
}