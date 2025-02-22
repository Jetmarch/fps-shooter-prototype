using System;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DeathObserver : IInitializable, IDisposable
    {
        private readonly ObjectState _objectState;
        private readonly UnitView _view;

        public DeathObserver(ObjectState objectState, UnitView view)
        {
            _objectState = objectState;
            _view = view;
        }

        public void Initialize()
        {
            _objectState.OnObjectDestroyed += _view.Die;
        }

        public void Dispose()
        {
            _objectState.OnObjectDestroyed -= _view.Die;
        }
    }
}