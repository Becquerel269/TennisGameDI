namespace TennisScoringDI.Services
{
    public interface IGameService
    {
        void GetThePlayers(int numberOfPlayers);

        void DisplayTheScoreTable();

        void PlayTheGame();
    }
}