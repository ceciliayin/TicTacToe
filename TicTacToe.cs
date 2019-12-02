using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    public class TicTacToe : ITicTacToe
    {
        private const char Player1 = 'X';
        private const char Player2 = 'O';

        private readonly IPrint _print;
        private readonly IBoard _board;
        private readonly IGameRules _gameRules;

        public TicTacToe(IPrint print, IBoard board, IGameRules gameRules)
        {
            _print = print;
            _board = board;
            _gameRules = gameRules;
        }

        public void Play()
        {
            int numberOfRounds = 1;
            GameResult gameResult;

            _print.PrintInitMessage();
            _board.PrintBoard();
            
            do
            {
                _print.PrintWhichPlayerShouldPlay(numberOfRounds);
                string position = Console.ReadLine();
                int choiceOfPlayer =_board.GetArrayIndex(position);

                _board.CheckIfPositionIsValid(position);

                if (_board.CheckIfPlaceIsTaken(Player1, Player2, numberOfRounds, choiceOfPlayer))
                {
                    numberOfRounds++;
                }

                _board.UpdateBoardArray(Player1, Player2, numberOfRounds, choiceOfPlayer);
                _board.PrintBoard();
                gameResult = _gameRules.CheckIfThePlayerWin(Player1, Player2, _board.GetBoardArray(),numberOfRounds);
                numberOfRounds++;
                
            } while (gameResult == GameResult.None);
            {
                _board.PrintGameResult(gameResult,numberOfRounds);
            }
        }
    }
}