using System;
using Cysharp.Threading.Tasks;
using FPSShooter.Modules.Core.Tasks;
using HomeworkSaveLoad.SaveSystem;
using UnityEngine;
using VContainer;

namespace FPSShooter.Game.Core.Tasks
{
    [Serializable]
    // ReSharper disable once InconsistentNaming
    public sealed class LoadGame_AsyncTask : IAsyncTask
    {
        private SaveLoadManager _saveLoadManager;
        
        [Inject]
        private void Config(SaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }
        
        public async UniTask ExecuteAsync()
        {
            await UniTask.Create(LoadGame);
        }

        private async UniTask LoadGame()
        {
            Debug.Log("Load game task started");
            _saveLoadManager.Load();
            await UniTask.Delay(1);
            Debug.Log("Load game task completed");
        }
    }
}