namespace Tic_Tac_Toe
{
    public interface IBoard
    {
        char[] GetBoardArray();
        void PrintBoard();
        int GetArrayIndex(string position);
        void CheckIfPositionIsValid(string position);
        void UpdateBoardArray(char player1, char player2, int roundCounter, int choiceOfPlayer);
        bool CheckIfPlaceIsTaken(char player1, char player2, int choiceOfPlayer);
        void PrintGameResult(GameResult gameResult, int numberOfRounds);
    }
}