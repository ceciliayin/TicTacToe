using System;
using System.Threading;

namespace Tic_Tac_Toe
{ 
    static class TicTacToe
    {
        private const char Player1 = 'X';
        private const char Player2 = 'O';
        
        public static void Main(string[] args)
        {    
            
            IPrint printTheMessage=new Print();
            IBoard newBoard = new Board(printTheMessage);
            IGameRules newGameRules= new GameRules(printTheMessage);
            
            int result;
            int roundCounter = 1;

            printTheMessage.PrintInitMessage();
            newBoard.PrintBoard();

            do
            {
                printTheMessage.PrintWhichPlayerShouldPlay(roundCounter);
                string position = Console.ReadLine();
                int choiceOfPlayer = newBoard.GetArrayIndex(position);

                if (choiceOfPlayer == 10)
                {
                    printTheMessage.PrintTheMessage("The position coordinate is invalid, try again......");
                    printTheMessage.PrintTheMessage("\n");
                    Thread.Sleep(2000);
                }

                if (newBoard.CheckIfPlaceIsTaken(Player1, Player2, roundCounter, choiceOfPlayer))
                {
                    roundCounter++;
                }

                newBoard.UpdateTokens(Player1, Player2, roundCounter, choiceOfPlayer);
                roundCounter++;
                newBoard.PrintBoard();
                result = newGameRules.CheckIfThePlayerWin(Player1,Player2, newBoard.GetBoardArray());
                

            } while (result==0);

            {
                newGameRules.CheckIfConditionIsWinning(result,roundCounter);
            }
        }
    }
}