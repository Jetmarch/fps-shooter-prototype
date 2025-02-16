using Cysharp.Threading.Tasks;

namespace FPSShooter.Core.Systems.TaskSystem
{
    public interface IAsyncTask
    {
        UniTask ExecuteAsync();
    }
}