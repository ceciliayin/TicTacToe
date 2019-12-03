using System;
using System.Threading;

namespace Tic_Tac_Toe
{
    public enum Player
    {
        X,O
    }
    public class TicTacToe : ITicTacToe
    {
        private readonly IPrint _print;
        private readonly IBoard _board;
        private readonly IGameRules _gameRules;
        public TicTacToe(IPrint print, IBoard board, IGameRules gameRules)
        {
            _print = print;
            _board = board;
            _gameRules = gameRules;
        }
        
        private Player _currentPlayer = Player.X;
        private GameResult _gameResult = GameResult.None;

        public void Play()
        {
            InitializeGame();

            while (_gameResult == GameResult.None)
            {
                _print.PrintWhichPlayerShouldPlay(_currentPlayer);
                string position = Console.ReadLine();
                int choiceOfPlayer = _board.GetArrayIndex(position);

                _board.CheckIfPositionIsValid(position,_currentPlayer);

                if (_board.CheckIfPlaceIsTaken(choiceOfPlayer))
                {
                    _currentPlayer = _currentPlayer == Player.X ? Player.X : Player.O;
                }

                _board.UpdateBoardArray(choiceOfPlayer, _currentPlayer);
                _board.PrintBoard();
                _gameResult = _gameRules.CheckIfThePlayerWin(_board.GetBoardArray());
                _currentPlayer = _currentPlayer == Player.X ? Player.O : Player.X;
            }

            PrintWiningMessage();
        }

        private void InitializeGame()
        {
            _print.PrintInitMessage();
            _board.PrintBoard();
        }

        private void PrintWiningMessage()
        {
            if (_gameResult == GameResult.Win)
            {
                if (_currentPlayer == Player.X)
                {
                    _print.PrintTheMessage("Well done Player 2 won the game!");
                }
                else
                {
                    _print.PrintTheMessage("Well done Player 1 won the game!");
                }
            }

            if (_gameResult == GameResult.Draw)
            {
                _print.PrintTheMessage("Draw");
            }
        }
    }
    
}