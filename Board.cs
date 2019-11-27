using System;

namespace Tic_Tac_Toe
{
    public interface IBoard
    {
        void PrintBoard(char[] boardArray);
        int GetArrayIndex(string position);
        void UpdateTokens(char player1, char player2, char[] boardArray, int roundCounter, int choiceOfPlayer);
    }

    public class Board : IBoard
    {
        
        Print _printTheMessage=new Print();

        public char[] BoardArray = {'.', '.', '.', '.', '.', '.', '.', '.', '.', '.'};
        public void PrintBoard(char[] boardArray)
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
            return 10;
        }
        
        public void UpdateTokens(char player1, char player2, char[] boardArray, int roundCounter, int choiceOfPlayer)
        {
            if (choiceOfPlayer == 0)
            {
                roundCounter++;
                _printTheMessage.PrintTheMessage($"Player {(roundCounter % 2) + 1} has given up for this round");
                _printTheMessage.PrintTheMessage("\n");
                roundCounter += 2;
            }

            if (choiceOfPlayer != 0 && boardArray[choiceOfPlayer] != player1 && boardArray[choiceOfPlayer] != player2 )
            {
                if (roundCounter % 2 == 0)
                {
                    boardArray[choiceOfPlayer] = player2;
                }

                else
                {
                    boardArray[choiceOfPlayer] = player1;
                }
                _printTheMessage.PrintTheMessage("Move accepted, here's the current board: ");
                _printTheMessage.PrintTheMessage("\n");
            }
        } 
    }
}