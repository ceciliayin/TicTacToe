using System;
using System.Threading;

namespace Tic_Tac_Toe
{ 
    static class Program
    { 
        static void Main()
        {
            IPrint print = new Print();
            IGameRules gameRules=new GameRules();
            IBoard board= new Board(print);
            ITicTacToe newGame = new TicTacToe(print,board,gameRules);
            newGame.Play();
        }
    }
}