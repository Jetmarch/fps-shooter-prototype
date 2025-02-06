namespace FPSShooter.Core.Managers
{
    public interface IPauseListener : IGameLoopListener
    {
        void OnPause();
        void OnResume();
    }
}