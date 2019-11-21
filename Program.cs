using System;
using System.Net;

namespace Tic_Tac_Toe
{
    class TicTacToe
    {
        static char[] boardArray = {'0', '.', '.', '.', '.', '.', '.', '.', '.','.'}; 
        static string _position;
        static int _choice;
        
        static char Player1 = char.Parse("X");
        static char Player2 = char.Parse("O");

        static int _count = 1;

        static int _result;


        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Tic Tac Toe!");
                Console.WriteLine("Here's the current board:");
                Board();

                if (_count % 2 == 0)
                {
                    Console.WriteLine("Player 2 enter a coord x,y to place your X or enter 'q' to give up: ");
                    _position = Console.ReadLine();
                    PositionCoordinate();
                    if (boardArray[_choice] != Player1 && boardArray[_choice] != Player2)
                    {   
                        Console.WriteLine("Move accepted, here's the current board: ");
                        boardArray[_choice] = Player2;
                        Board();
                        _count++;
                    }
                    else if (boardArray[_choice] == Player1 || boardArray[_choice] == Player2)
                    {
                        Console.WriteLine("Oh no, a piece is already at this place! Try again..");
                    }
                }
                
                if(_count%2 !=0) 
                {
                    Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
                    _position = Console.ReadLine();
                    PositionCoordinate();
                    if (boardArray[_choice] != Player1 && boardArray[_choice] != Player2)
                    {
                        Console.WriteLine("Move accepted, here's the current board: ");
                        boardArray[_choice] = Player1;
                        Board();
                        _count++;
                    }
                    else if (boardArray[_choice] == Player1 || boardArray[_choice] == Player2)
                    {
                        Console.WriteLine("Oh no, a piece is already at this place! Try again..");
                    }
                }
                
                _result = CheckIfThePlayerWin();
            }

            //calling win function to check if winning
            while (_result != 1 && _result != -1);
            {
                Console.Clear();
                Board();


                if (_result == 0 && _choice == 0)
                {
                    Console.WriteLine("Player{0} has given up", (_count %2)+1 );
                }
                
                if (_result == 1)
                {
                    Console.WriteLine("Move accepted, well done Player {0} won the game!", (_count % 2) + 1);
                }

                if (_result == -1)
                {
                    Console.WriteLine("Draw");
                }
            }
            
            Console.ReadLine();
        }
        


        private static void Board()
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

        private static int PositionCoordinate()
        {
            //check the user input position
            string pos1="1,1";
            string pos2="1,2";
            string pos3="1,3";
            string pos4="2,1";
            string pos5="2,2";
            string pos6="2,3";
            string pos7="3,1";
            string pos8="3,2";
            string pos9="3,3";
            string pos10 = "q";

            if (_position==pos1)
            {
                _choice = 1;
            }
            if (_position==pos2)
            {
                _choice = 2;
            }
            if (_position==pos3)
            {
                _choice = 3;
            }
            if (_position==pos4)
            {
                _choice = 4;
            }
            if (_position==pos5)
            {
                _choice = 5;
            }
            if (_position==pos6)
            {
                _choice = 6;
            }
            if (_position==pos7)
            {
                _choice = 7;
            }
            if (_position==pos8)
            {
                _choice = 8;
            }
            if (_position==pos9)
            {
                _choice = 9;
            }
            if (_position==pos10)
            {
                _choice = 0;
            }

            return _choice;
        }
    }
}