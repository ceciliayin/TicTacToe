namespace Tic_Tac_Toe
{
    public interface IPrint
    {
        void PrintTheMessage(string message);
        void PrintInitMessage();
        void PrintWhichPlayerShouldPlay(int roundCounter);
    }
}