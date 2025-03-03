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
    public sealed class SaveGame_AsyncTask : IAsyncTask
    {
        private SaveLoadManager _saveLoadManager;

        [Inject]
        private void Config(SaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }
        
        public async UniTask ExecuteAsync()
        {
            await UniTask.Create(SaveGame);
        }

        private async UniTask SaveGame()
        {
            Debug.Log("Save game task started");
            _saveLoadManager.Save();
            await UniTask.Delay(1);
            Debug.Log("Save game task completed");
        }
    }
}