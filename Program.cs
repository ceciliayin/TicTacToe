using System;
using System.Threading;

namespace Tic_Tac_Toe
{ 
    static class Program
    { 
        static void Main(string [] args)
        {
            IPrint print = new Print();
            IGameRules gameRules=new GameRules();
            IBoard board= new Board(print,gameRules);

            ITicTacToe newGame = new TicTacToe(print,board, gameRules);
            newGame.Play();
        }
    }
}