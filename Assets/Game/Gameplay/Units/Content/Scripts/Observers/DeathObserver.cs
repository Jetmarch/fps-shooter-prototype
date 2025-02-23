using System;
using FPSShooter.Game.Gameplay.Impact;
using FPSShooter.Modules.Units;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DeathObserver : IInitializable, IDisposable
    {
        private readonly TearingApartOnDeathMechanic _deathMechanic;
        private readonly UnitView _view;

        public DeathObserver(TearingApartOnDeathMechanic deathMechanic, UnitView view)
        {
            _deathMechanic = deathMechanic;
            _view = view;
        }

        public void Initialize()
        {
            _deathMechanic.OnTearApart += _view.TearApartDeath;
            _deathMechanic.OnSimpleDeath += _view.SimpleDeath;
        }

        public void Dispose()
        {
            _deathMechanic.OnSimpleDeath -= _view.SimpleDeath;
            _deathMechanic.OnTearApart -= _view.TearApartDeath;
        }
    }
}