namespace FPSShooter.Core.Managers
{
    public interface IUpdateListener : IGameLoopListener
    {
        void OnUpdate(float deltaTime);
    }
}