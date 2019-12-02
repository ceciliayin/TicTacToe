namespace Tic_Tac_Toe
{
    public interface IGameRules
    { 
        GameResult CheckIfThePlayerWin(char[] boardArray);
    }
}