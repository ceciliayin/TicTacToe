using System;
using System.Threading;

namespace Tic_Tac_Toe
{ 
    static class Program
    { 
        static void Main()
        {
            ITicTacToe newGame = new TicTacToe(new Print(),new Board(new Print()),new GameRules());
            newGame.Play(); 
        }
    }
}