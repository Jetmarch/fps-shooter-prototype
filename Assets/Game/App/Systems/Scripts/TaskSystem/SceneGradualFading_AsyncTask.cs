using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Core.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace FPSShooter.Game.Core.Tasks
{
    [Serializable]
    // ReSharper disable once InconsistentNaming
    public sealed class SceneGradualFading_AsyncTask : IAsyncTask
    {
        [SerializeField] private float _fadeDuration = 2f;
        [SerializeField] private float _fadeEndValue = 0f;
        private Image _fadeImage;
        [Inject]
        private void Configure(Image fadeImage)
        {
            Debug.Log("Loading Scene GradualFading");
            _fadeImage = fadeImage;
        }
        
        public UniTask ExecuteAsync()
        {
            return UniTask.Create(FadeOut);
        }
        
        private async UniTask FadeOut()
        {
            Debug.Log("Fade task started");
            await _fadeImage.DOFade(_fadeEndValue, _fadeDuration).ToUniTask();
            Debug.Log("Fade task completed");
        }
    }

    [Serializable]
    // ReSharper disable once InconsistentNaming
    public sealed class StartGame_AsyncTask : IAsyncTask
    {
        private GameLoopManager _gameLoopManager;
        
        [Inject]
        private void Configure(GameLoopManager gameLoopManager)
        {
            _gameLoopManager = gameLoopManager;
        }

        public UniTask ExecuteAsync()
        {
            return UniTask.Create(StartGame);
        }

        private async UniTask StartGame()
        {
            _gameLoopManager.StartGame();
            await UniTask.WaitForSeconds(0.1f);
        }
    }
}