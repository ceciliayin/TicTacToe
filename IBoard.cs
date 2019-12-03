namespace Tic_Tac_Toe
{
    public interface IBoard
    {   
        char[] GetBoardArray();
        void PrintBoard();
        int GetArrayIndex(string position);
        void CheckIfPositionIsValid(string position,Player player);
        void UpdateBoardArray(int choiceOfPlayer,Player currentPlayer);
        bool CheckIfPlaceIsTaken(int choiceOfPlayer);
    }
}