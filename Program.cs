using System;
using System.Net;
using System.Threading;

namespace Tic_Tac_Toe
{
    class TicTacToe
    {
        static char[] boardArray = {'.', '.', '.','.','.', '.', '.','.','.','.'};
        private static string _position;
        static char Player1 = char.Parse("X");
        static char Player2 = char.Parse("O");

        static void Main(string[] args)
        {
            int result;
            int roundCounter = 1;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Welcome to Tic Tac Toe!");
                Console.WriteLine("Here's the current board:");
                PrintBoard();

                if (roundCounter % 2 == 0)
                {    
                    Console.WriteLine("Player 2 enter a coord x,y to place your X or enter 'q' to give up: ");
                }

                else
                {
                    Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
                }
                
                _position = Console.ReadLine(); 
                var choiceOfPlayer = GetArrayIndex();

                if (choiceOfPlayer == 10)
                {
                    Console.WriteLine("The position coordinate is invalid, try again......");
                    Console.WriteLine("\n");
                    Thread.Sleep(2000);
                }

                if (choiceOfPlayer == 0)
                {   
                    roundCounter++;
                    Console.WriteLine("Player {0} has given up for this round",(roundCounter % 2)+1 );
                    roundCounter=roundCounter+2;
                }

                if (choiceOfPlayer != 0 && boardArray[choiceOfPlayer] != Player1 && boardArray[choiceOfPlayer] != Player2 )
                {
                    if (roundCounter % 2 == 0)
                    {
                        boardArray[choiceOfPlayer] = Player2;
                    }

                    else
                    {
                        boardArray[choiceOfPlayer] = Player1;
                    }
                    
                    Console.WriteLine("Move accepted, here's the current board: ");
                    PrintBoard();
                    roundCounter++;
                }
                else if (boardArray[choiceOfPlayer] == Player1 && choiceOfPlayer !=0)
                { 
                    Console.WriteLine("Oh no, a piece is already at this place! Try again..");
                }
                else if (boardArray[choiceOfPlayer] == Player2 && choiceOfPlayer !=0)
                { 
                    Console.WriteLine("Oh no, a piece is already at this place! Try again..");
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
                    Console.WriteLine("Draw");
                }
            }
        }

        private static void PrintBoard()
        {
            Console.WriteLine("  {0}    {1}    {2}", boardArray[1], boardArray[2], boardArray[3]);
            Console.WriteLine("  {0}    {1}    {2}", boardArray[4], boardArray[5], boardArray[6]);
            Console.WriteLine("  {0}    {1}    {2}", boardArray[7], boardArray[8], boardArray[9]);
        }

        private static int CheckIfThePlayerWin()
        {
            //check the horizontal condition
            if (boardArray[1] == Player1 && boardArray[2] == Player1 && boardArray[3]==Player1)
            {
                return 1;
            }
            
            if (boardArray[1] == Player2 && boardArray[2] == Player2 && boardArray[3]==Player2)
            {
                return 1;
            }

            if (boardArray[4] == Player1 && boardArray[5] == Player1 && boardArray[6] == Player1)
            {
                return 1;
            }
            
            if (boardArray[4] == Player2 && boardArray[5] == Player2 && boardArray[6] == Player2)
            {
                return 1;
            }

            if (boardArray[7] == Player1 && boardArray[8] == Player1 && boardArray[9] == Player1)
            {
                return 1;
            }
            
            if (boardArray[7] == Player2 && boardArray[8] == Player2 && boardArray[9] == Player2)
            {
                return 1;
            }

            //check the vertical condition
            if (boardArray[1] == Player1 &&  boardArray[4] ==Player1 && boardArray[7] == Player1)
            {
                return 1;
            }
            if (boardArray[1] == Player2 &&  boardArray[4] ==Player2 && boardArray[7] == Player2)
            {
                return 1;
            }

            if (boardArray[2] == Player1 && boardArray[5] ==Player1 && boardArray[8] == Player1)
            {
                return 1;
            }
            
            if (boardArray[2] == Player2 && boardArray[5] ==Player2 && boardArray[8] == Player2)
            {
                return 1;
            }

            if (boardArray[3] == Player1 && boardArray[6] ==Player1 && boardArray[9] == Player1)
            {
                return 1;
            }
            if (boardArray[3] == Player2 && boardArray[6] ==Player2 && boardArray[9] == Player2)
            {
                return 1;
            }

            //check the diagonal condition
            if (boardArray[1] == Player1 && boardArray[5] == Player1 && boardArray[9]==Player1)
            {
                return 1;
            }
            if (boardArray[1] == Player2 && boardArray[5] == Player2 && boardArray[9]==Player2)
            {
                return 1;
            }

            if (boardArray[3] == Player1 && boardArray[5]==Player1 && boardArray[7] == Player1)
            {
                return 1;
            }
            
            if (boardArray[3] == Player2 && boardArray[5]==Player2 && boardArray[7] == Player2)
            {
                return 1;
            }
            //check if it's a draw
            if (boardArray[1] != '.' && boardArray[2] != '.' && boardArray[3] != '.' && boardArray[4] != '.' && boardArray[5] != '.' && boardArray[6] != '.' && boardArray[7] != '.' && boardArray[8] != '.' && boardArray[9] != '.')
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

            if(_position==coordinatesStrings[10])
            {
                return 0;
            }
            return 10; 
        }
    }
}