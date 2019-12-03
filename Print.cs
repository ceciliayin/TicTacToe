using System;

namespace Tic_Tac_Toe
{ 
    public class Print : IPrint
    {
        public void PrintTheMessage(string message)
        {
            Console.Write(message);
        }

        public void PrintInitMessage()
        {
            PrintTheMessage("Welcome to Tic Tac Toe!");
            PrintTheMessage("\n");
            PrintTheMessage("Here's the current board:");
            PrintTheMessage("\n");
        }
        public void PrintWhichPlayerShouldPlay(Player currentPlayer)
        {
            if (currentPlayer == Player.O)
            {
                PrintTheMessage("Player 2 enter a coord x,y to place your X or enter 'q' to give up: ");
            }

            else
            {
                PrintTheMessage("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
            }
        }
    }
}