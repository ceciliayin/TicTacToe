using System;
using System.Net;
using System.Threading;

namespace Tic_Tac_Toe
{
    class TicTacToe
    { 
        static void Main(string[] args)
        {
            int result;
            int roundCounter = 1;
            char[] boardArray = {'.', '.', '.', '.', '.', '.', '.', '.', '.', '.'};

            do
            {
                const char player1 = 'X';
                const char player2 = 'O';

                PrintTheMessage("Welcome to Tic Tac Toe!");
                PrintTheMessage("Here's the current board:");
                PrintBoard(boardArray);
                PrintWhichPlayerShouldPlay(roundCounter);

                string position = Console.ReadLine();
                int choiceOfPlayer = GetArrayIndex(position);

                if (choiceOfPlayer == 10)
                {
                    PrintTheMessage("The position coordinate is invalid, try again......");
                    PrintTheMessage("\n");
                    Thread.Sleep(2000);
                }

                if ((boardArray[choiceOfPlayer] == player1 && choiceOfPlayer != 0) || (boardArray[choiceOfPlayer] == player2 && choiceOfPlayer != 0))
                {
                    PrintTheMessage("Oh no, a piece is already at this place! Try again..");
                    roundCounter++;
                }

                UpdateTokens(player1, player2, boardArray, roundCounter, choiceOfPlayer);
                roundCounter++;
                
                result = CheckIfThePlayerWin(player1, player2, boardArray);
            }while (result != 1 && result != -1);
            {
                CheckIfConditionIsWinning(result, roundCounter, boardArray);
            }
        }

        private static void PrintTheMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintTheMessageWithNumber(string message, int roundCounter)
        {
            Console.WriteLine(message, roundCounter);
        }

        private static void PrintWhichPlayerShouldPlay(int roundCounter)
        {
            if (roundCounter % 2 == 0)
            {
                PrintTheMessage("Player 2 enter a coord x,y to place your X or enter 'q' to give up: ");
            }

            else
            {
                PrintTheMessage("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            }
        }

        private static void PrintBoard(char[] boardArray)
        {
            Console.WriteLine("  {0}    {1}    {2}", boardArray[1], boardArray[2], boardArray[3]);
            Console.WriteLine("  {0}    {1}    {2}", boardArray[4], boardArray[5], boardArray[6]);
            Console.WriteLine("  {0}    {1}    {2}", boardArray[7], boardArray[8], boardArray[9]);
        }

        private static int CheckIfThePlayerWin(char player1, char player2, char[] boardArray)
        {
            //check the horizontal condition
            int i = 1;
            for (i = 1; i < 8; i += 3)
            {
                if ((boardArray[i] == player1 && boardArray[i + 1] == player1 && boardArray[i + 2] == player1) ||
                    (boardArray[i] == player2 && boardArray[i + 1] == player2 && boardArray[i + 2] == player2))
                {
                    return 1;
                }
            }

            //check the vertical condition
            for (i = 1; i < 4; i++)
            {
                if ((boardArray[i] == player1 && boardArray[i + 3] == player1 && boardArray[i + 6] == player1) ||
                    (boardArray[i] == player2 && boardArray[i + 3] == player2 && boardArray[i + 6] == player2))
                {
                    return 1;
                }
            }

            //check diagonal condition
            for (i = 1; i < 2; i++)
            {
                if ((boardArray[i] == player1 && boardArray[i + 4] == player1 && boardArray[i + 8] == player1) ||
                    (boardArray[i] == player2 && boardArray[i + 4] == player2 && boardArray[i + 8] == player2))
                    return 1;

            }

            for (i = 3; i < 4; i++)
            {
                if ((boardArray[i] == player2 && boardArray[i + 2] == player2 && boardArray[i + 4] == player2) ||
                    (boardArray[i] == player1 && boardArray[i + 2] == player1 && boardArray[i + 4] == player1))
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

        private static int GetArrayIndex(string position)
        {
            var coordinatesStrings = new string[11]{"0,0", "1,1", "1,2", "1,3", "2,1", "2,2", "2,3", "3,1", "3,2", "3,3", "q"};
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

            return 10;
        }

        private static void UpdateTokens(char player1, char player2, char[] boardArray, int roundCounter, int choiceOfPlayer)
        {
            if (choiceOfPlayer == 0)
            {
                roundCounter++;
                PrintTheMessageWithNumber("Player {0} has given up for this round", (roundCounter % 2) + 1);
                roundCounter += 2;
            }

            if (choiceOfPlayer != 0 && boardArray[choiceOfPlayer] != player1 && boardArray[choiceOfPlayer] != player2)
            {
                if (roundCounter % 2 == 0)
                {
                    boardArray[choiceOfPlayer] = player2;
                }

                else
                {
                    boardArray[choiceOfPlayer] = player1;
                }
                PrintTheMessage("Move accepted, here's the current board: ");
                PrintBoard(boardArray);
            }
        }
        
        private static void CheckIfConditionIsWinning(int result, int roundCounter, char[] boardArray)
        {
            Console.Clear();
            PrintBoard(boardArray);

            if (result == 1)
            {
                PrintTheMessageWithNumber("Move accepted, well done Player {0} won the game!", (roundCounter % 2) + 1);
            }

            if (result == -1)
            {
                PrintTheMessage("Draw");
            }
        }
    }
}