using System;
using Cysharp.Threading.Tasks;
using FPSShooter.Modules.Core.Tasks;
using UnityEngine;

namespace FPSShooter.Game.Core.Tasks
{
    [Serializable]
    // ReSharper disable once InconsistentNaming
    public sealed class DummyTask_AsyncTask : IAsyncTask
    {
        public bool _completed;
        public async UniTask ExecuteAsync()
        {
            await UniTask.Create(DoDummyWork);
        }

        private async UniTask DoDummyWork()
        {
            Debug.Log("Dummy task started");
            await UniTask.WaitUntil(() => _completed);
            Debug.Log("Dummy task completed");
        }
    }
}