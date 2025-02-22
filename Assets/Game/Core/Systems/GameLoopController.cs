using System;
using System.Collections.Generic;
using FPSShooter.Modules.Core.GameLoop;
using VContainer.Unity;

namespace FPSShooter.Game.Core.GameLoop
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class GameLoopController : IInitializable, IDisposable
    {
        private readonly IGameLoopManager _gameLoopManager;
        private readonly IEnumerable<IGameLoopListener> _gameLoopGameLoopListeners;

        public GameLoopController(IGameLoopManager gameLoopManager, IEnumerable<IGameLoopListener> gameLoopListeners)
        {
            _gameLoopManager = gameLoopManager;
            _gameLoopGameLoopListeners = gameLoopListeners;
        }
        
        public void Initialize()
        {
            foreach (var listener in _gameLoopGameLoopListeners)
            {
                _gameLoopManager.AddListener(listener);
            }
        }

        public void Dispose()
        {
            foreach (var listener in _gameLoopGameLoopListeners)
            {
                _gameLoopManager.RemoveListener(listener);
            }
        }
    }
}