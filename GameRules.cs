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
            if (numberOfRounds % 2 == 0)
            {
                //check the horizontal condition
                for (i = 1; i < 8; i += 3)
                {
                    if (boardArray[i] == player2 && boardArray[i + 1] == player2 && boardArray[i + 2] == player2)
                    {
                        return GameResult.Win;
                    }
                }
                //check the vertical condition
                for (i = 1; i < 4; i++)
                {
                    if (boardArray[i] == player2 && boardArray[i + 3] == player2 && boardArray[i + 6] == player2)
                    {
                        return GameResult.Win;
                    }
                }
                //check the diagonal condition
                for (i = 1; i < 2; i++)
                {
                    if (boardArray[i] == player2 && boardArray[i + 4] == player2 && boardArray[i + 8] == player2)
                    {
                        return GameResult.Win;
                    }

                }

                for (i = 3; i < 4; i++)
                {
                    if (boardArray[i] == player2 && boardArray[i + 2] == player2 && boardArray[i + 4] == player2)
                    {
                        return GameResult.Win;
                    }
                }
            }

            if(numberOfRounds%2 !=0)
            {
                for (i = 1; i < 8; i += 3)
                {
                    if (boardArray[i] == player1 && boardArray[i + 1] == player1 && boardArray[i + 2] == player1)
                    {
                        return GameResult.Win;;
                    }
                }
                for (i = 1; i < 4; i++)
                {
                    if (boardArray[i] == player1 && boardArray[i + 3] == player1 && boardArray[i + 6] == player1)
                    {
                        return GameResult.Win;;
                    }
                }
                for (i = 1; i < 2; i++)
                {
                    if (boardArray[i] == player1 && boardArray[i + 4] == player1 && boardArray[i + 8] == player1)
                    {
                        return GameResult.Win;
                    }
                }

                for (i = 3; i < 4; i++)
                {
                    if (boardArray[i] == player1 && boardArray[i + 2] == player1 && boardArray[i + 4] == player1)
                    {
                        return GameResult.Win;
                        
                    }
                }
            }

            //check if it's a draw
            else if (boardArray[1] != '.' && boardArray[2] != '.' && boardArray[3] != '.' && boardArray[4] != '.' &&
                boardArray[5] != '.' && boardArray[6] != '.' && boardArray[7] != '.' && boardArray[8] != '.' &&
                boardArray[9] != '.')
            {
                return GameResult.Draw;
            }
        
            return GameResult.None; 
        }
    }
}