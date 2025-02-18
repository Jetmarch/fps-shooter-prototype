using Cysharp.Threading.Tasks;

namespace FPSShooter.Modules.Core.Tasks
{
    public interface IAsyncTask
    {
        UniTask ExecuteAsync();
    }
}