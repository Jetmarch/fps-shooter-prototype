namespace FPSShooter.Game.Gameplay.UI
{
    public interface IMenuPresenter 
    {
        void SaveGame();
        void LoadGame();
        void ExitGame();
        void Toggle();
    }
}