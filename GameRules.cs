using System;

using System;

namespace Tic_Tac_Toe
{
    public enum GameResult
    {
        Win, Draw, None 
    }

    public class GameRules : IGameRules
    {
        public GameResult CheckIfThePlayerWin(char player1, char player2, char[] boardArray,int numberOfRounds)
        {
            int i;
            
            //check the horizontal condition
            for (i = 1; i < 8; i += 3)
            {
                if (boardArray[i] == boardArray[i+1]&& boardArray[i + 1] ==  boardArray[i + 2] && boardArray[i] != '.')
                {
                    return GameResult.Win;
                }
            }
            
            //check the vertical condition
            for (i = 1; i < 4; i++)
            {
                if (boardArray[i] == boardArray[i + 3]  && boardArray[i + 3] == boardArray[i+6] && boardArray[i] != '.')
                {
                    return GameResult.Win;
                }
            }
            
            //check the diagonal condition
            for (i = 1; i < 2; i++)
            {
                if (boardArray[i] == boardArray[i + 4] && boardArray[i + 8] == boardArray[i+4] && boardArray[i] != '.')
                {
                    return GameResult.Win;
                }
            }

            for (i = 3; i < 4; i++)
            {
                if (boardArray[i] == boardArray[i + 2] && boardArray[i + 4] == boardArray[i+2] && boardArray[i] != '.')
                {
                    return GameResult.Win;
                }
            }

            //check if it's a draw
            if (boardArray[1] != '.' && boardArray[2] != '.' && boardArray[3] != '.' && boardArray[4] != '.' &&
                boardArray[5] != '.' && boardArray[6] != '.' && boardArray[7] != '.' && boardArray[8] != '.' &&
                boardArray[9] != '.')
            {
                return GameResult.Draw;
            }
        
            return GameResult.None; 
        }
    }
}