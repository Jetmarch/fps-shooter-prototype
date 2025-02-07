namespace FPSShooter.Core.Managers
{
    public interface IFixedUpdateListener : IGameLoopListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}