namespace Tic_Tac_Toe
{
    public interface IGameRules
    {
        GameResult CheckIfThePlayerWin(char player1, char player2, char[] boardArray,int numberOfRounds);
    }
}