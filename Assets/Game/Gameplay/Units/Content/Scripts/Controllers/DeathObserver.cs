using System;
using FPSShooter.Game.Gameplay.Impact;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DeathObserver : IInitializable, IDisposable
    {
        private readonly DeathService _deathService;
        private readonly TearApartOnDeathMechanic _tearApartOnDeathMechanic;
        private readonly DeathMechanic _dieMechanic;

        public DeathObserver(DeathService deathService, TearApartOnDeathMechanic tearApartOnDeathMechanic, DeathMechanic dieMechanic)
        {
            _deathService = deathService;
            _tearApartOnDeathMechanic = tearApartOnDeathMechanic;
            _dieMechanic = dieMechanic;
        }

        public void Initialize()
        {
            _deathService.OnTearApart += _tearApartOnDeathMechanic.Death;
            _deathService.OnSimpleDeath += _dieMechanic.Die;
        }

        public void Dispose()
        {
            _deathService.OnSimpleDeath -= _dieMechanic.Die;
            _deathService.OnTearApart -= _tearApartOnDeathMechanic.Death;
        }
    }
}