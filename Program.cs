﻿using System;
using System.Threading;

namespace Tic_Tac_Toe
{ 
    static class TicTacToe
    {
        private const char Player1 = 'X';
        private const char Player2 = 'O';
        
        public static void Main(string[] args)
        {
            Board newBoard = new Board(); 
            Print printTheMessage=new Print();
            GameRules newGameRules= new GameRules();

            int result;
            int roundCounter = 1;

            printTheMessage.PrintInitMessage();
            newBoard.PrintBoard(newBoard.BoardArray);

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

                if (newBoard.BoardArray[choiceOfPlayer] == Player1 && choiceOfPlayer != 0 || newBoard.BoardArray[choiceOfPlayer] == Player2 && choiceOfPlayer != 0)
                {
                    printTheMessage.PrintTheMessage("Oh no, a piece is already at this place! Try again..");
                    printTheMessage.PrintTheMessage("\n");
                    roundCounter++;
                }

                newBoard.UpdateTokens(Player1, Player2, newBoard.BoardArray, roundCounter, choiceOfPlayer);
                roundCounter++;
                newBoard.PrintBoard(newBoard.BoardArray);
                result = newGameRules.CheckIfThePlayerWin(Player1,Player2, newBoard.BoardArray);

            } while (result==0);
            {
                newGameRules.CheckIfConditionIsWinning(result,roundCounter,newBoard.BoardArray);
            }
        }
    }
}