namespace FPSShooter.Core.Managers
{
    public interface ILateUpdateListener : IGameLoopListener
    {
        void OnLateUpdate(float deltaTime);
    }
}