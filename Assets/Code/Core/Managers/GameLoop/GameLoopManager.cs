using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace FPSShooter.Core.Managers
{
    public sealed class GameLoopManager : MonoBehaviour
    {
        private readonly List<IGameLoopListener> _gameLoopListeners = new();
        private readonly List<IUpdateListener> _updateListeners = new();
        private readonly List<IFixedUpdateListener> _fixedUpdateListeners = new();
        private readonly List<ILateUpdateListener> _lateUpdateListeners = new();

        private GameState _gameState;

        [Inject]
        public void Construct(IEnumerable<IGameLoopListener> listeners)
        {
            foreach (var listener in listeners)
            {
                AddListener(listener);
            }
        }

        public void AddListener(IGameLoopListener listener)
        {
            switch (listener)
            {
                case IUpdateListener updateListener:
                    _updateListeners.Add(updateListener);
                    break;
                case IFixedUpdateListener fixedUpdateListener:
                    _fixedUpdateListeners.Add(fixedUpdateListener);
                    break;
                case ILateUpdateListener lateUpdateListener:
                    _lateUpdateListeners.Add(lateUpdateListener);
                    break;
            }

            _gameLoopListeners.Add(listener);
        }

        public void RemoveListener(IGameLoopListener listener)
        {
            switch (listener)
            {
                case IUpdateListener updateListener:
                    _updateListeners.Remove(updateListener);
                    break;
                case IFixedUpdateListener fixedUpdateListener:
                    _fixedUpdateListeners.Remove(fixedUpdateListener);
                    break;
                case ILateUpdateListener lateUpdateListener:
                    _lateUpdateListeners.Remove(lateUpdateListener);
                    break;
            }
            _gameLoopListeners.Remove(listener);
        }
        
        private void Update()
        {
            if (_gameState != GameState.Running) return;
            
            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (_gameState != GameState.Running) return;
            
            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (_gameState != GameState.Running) return;
            
            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
            {
                _lateUpdateListeners[i].OnLateUpdate(deltaTime);
            }
        }

        [ContextMenu("Pause game")]
        public void PauseGame()
        {
            _gameState = GameState.Pause;

            for (int i = 0; i < _gameLoopListeners.Count; i++)
            {
                if (_gameLoopListeners[i] is IPauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }
        }

        [ContextMenu("Resume game")]
        public void ResumeGame()
        {
            _gameState = GameState.Running;
            
            for (int i = 0; i < _gameLoopListeners.Count; i++)
            {
                if (_gameLoopListeners[i] is IPauseListener pauseListener)
                {
                    pauseListener.OnResume();
                }
            }
        }
        
        [ContextMenu("Start game")]
        public void StartGame()
        {
            _gameState = GameState.Running;
        }
        
        [ContextMenu("Finish game")]
        public void FinishGame()
        {
            _gameState = GameState.Finished;
        }
    }
}
