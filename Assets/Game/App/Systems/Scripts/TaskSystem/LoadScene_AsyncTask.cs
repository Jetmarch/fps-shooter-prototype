using System;
using Cysharp.Threading.Tasks;
using FPSShooter.Modules.Core.Tasks;
using Sirenix.Serialization;
using UnityEngine.SceneManagement;

namespace FPSShooter.Game.Core.Tasks
{
    [Serializable]
    // ReSharper disable once InconsistentNaming
    public sealed class LoadScene_AsyncTask : IAsyncTask
    {
        [OdinSerialize] private string _sceneName;
        public async UniTask ExecuteAsync()
        {
            await UniTask.Create(LoadScene);
        }

        private async UniTask LoadScene()
        {
            await SceneManager.LoadSceneAsync(_sceneName);
        }
    }
}