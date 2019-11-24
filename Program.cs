using System;
using System.Net;
using System.Threading;

namespace Tic_Tac_Toe
{ 
    class TicTacToe
    {
        private static readonly char[] BoardArray = {'.', '.', '.','.','.', '.', '.','.','.','.'}; 
        private static string _position;
        private const char Player1 = 'X';
        private const char Player2 = 'O';

        static void Main(string[] args)
        {
            int result;
            int roundCounter = 1;

            do
            {
                PrintTheMessage("\n");
                PrintTheMessage("Welcome to Tic Tac Toe!");
                PrintTheMessage("Here's the current board:");
                PrintBoard();

                if (roundCounter % 2 == 0)
                {    
                    PrintTheMessage("Player 2 enter a coord x,y to place your X or enter 'q' to give up: ");
                }

                else
                {
                    PrintTheMessage("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
                }
                
                _position = Console.ReadLine(); 
                
                var choiceOfPlayer = GetArrayIndex();

                if (choiceOfPlayer == 10)
                {
                    PrintTheMessage("The position coordinate is invalid, try again......");
                    PrintTheMessage("\n");
                    Thread.Sleep(2000);
                }

                if (choiceOfPlayer == 0)
                {   
                    roundCounter++;
                    Console.WriteLine("Player {0} has given up for this round",(roundCounter % 2)+1 );
                    roundCounter=roundCounter+2;
                }

                if (choiceOfPlayer != 0 && BoardArray[choiceOfPlayer] != Player1 && BoardArray[choiceOfPlayer] != Player2 )
                {
                    if (roundCounter % 2 == 0)
                    {
                        BoardArray[choiceOfPlayer] = Player2;
                    }

                    else
                    {
                        BoardArray[choiceOfPlayer] = Player1;
                    }
                    
                    PrintTheMessage("Move accepted, here's the current board: ");
                    PrintBoard();
                    roundCounter++;
                }
                else if (BoardArray[choiceOfPlayer] == Player1 && choiceOfPlayer !=0)
                { 
                    PrintTheMessage("Oh no, a piece is already at this place! Try again..");
                }
                else if (BoardArray[choiceOfPlayer] == Player2 && choiceOfPlayer !=0)
                { 
                    PrintTheMessage("Oh no, a piece is already at this place! Try again..");
                }
                
                result = CheckIfThePlayerWin();
            }

            //calling win function to check if winning
            while (result != 1 && result != -1);
            {
                Console.Clear();
                PrintBoard();

                if (result == 1)
                {
                    Console.WriteLine("Move accepted, well done Player {0} won the game!", (roundCounter % 2) + 1);
                }

                if (result == -1)
                {
                    PrintTheMessage("Draw");
                }
            }
        }

        private static void PrintTheMessage(string message)
        { 
            Console.WriteLine(message);
        }
        private static void PrintBoard()
        {
            Console.WriteLine("  {0}    {1}    {2}", BoardArray[1], BoardArray[2], BoardArray[3]);
            Console.WriteLine("  {0}    {1}    {2}", BoardArray[4], BoardArray[5], BoardArray[6]);
            Console.WriteLine("  {0}    {1}    {2}", BoardArray[7], BoardArray[8], BoardArray[9]);
        }

        private static int CheckIfThePlayerWin()
        {    
            //check the horizontal condition
            int i = 1;
            for (i = 1; i < 8;i += 3)
            {
                if ((BoardArray[i] == Player1 && BoardArray[i + 1] == Player1 && BoardArray[i + 2] == Player1)||(BoardArray[i] == Player2 && BoardArray[i + 1] == Player2 && BoardArray[i + 2] == Player2))
                {
                    return 1;
                }

            }
            
            //check the vertical condition
            for (i = 1; i < 4; i++)
            {
                if ((BoardArray[i] == Player1 && BoardArray[i + 3] == Player1 && BoardArray[i + 6] == Player1)||(BoardArray[i] == Player2 && BoardArray[i + 3] == Player2 && BoardArray[i + 6] == Player2))
                {
                    return 1;
                }
                
            }
            
            //check diagonal condition
            for (i = 1; i < 2; i ++)
            {
                if ((BoardArray[i] == Player1 && BoardArray[i + 4] == Player1 && BoardArray[i + 8] == Player1) || (BoardArray[i] == Player2 && BoardArray[i + 4] == Player2 && BoardArray[i + 8] == Player2))
                    return 1;
                
            }

            for (i = 3; i < 4; i++)
            {
                if ((BoardArray[i] == Player2 && BoardArray[i + 2] == Player2 && BoardArray[i + 4] == Player2) || (BoardArray[i] == Player1 && BoardArray[i + 2] == Player1 && BoardArray[i + 4] == Player1))
                    return 1;
            }


            //check if it's a draw
            if (BoardArray[1] != '.' && BoardArray[2] != '.' && BoardArray[3] != '.' && BoardArray[4] != '.' && BoardArray[5] != '.' && BoardArray[6] != '.' && BoardArray[7] != '.' && BoardArray[8] != '.' && BoardArray[9] != '.')
            {
                return -1;
            } 
            
            return 0;
        }
        
        private static int GetArrayIndex()
        {
            var coordinatesStrings = new string[11] {"0,0", "1,1", "1,2", "1,3", "2,1", "2,2", "2,3", "3,1", "3,2", "3,3","q"};
            for (int i = 1; i < 10; i++)
            { 
                if (_position == coordinatesStrings[i])
                {
                    return i;
                }
            }

            if (_position==coordinatesStrings[10])
            {
                return 0;
            }
            return 10; 
        }
    }
}