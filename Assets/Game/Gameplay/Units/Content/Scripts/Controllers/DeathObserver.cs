using System;
using FPSShooter.Game.Gameplay.Impact;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DeathObserver : IInitializable, IDisposable
    {
        private readonly TearApartDeathService _tearApartDeathService;
        private readonly TearApartOnDeathMechanic _tearApartOnDeathMechanic;
        private readonly DieMechanic _dieMechanic;

        public DeathObserver(TearApartDeathService tearApartDeathService, TearApartOnDeathMechanic tearApartOnDeathMechanic, DieMechanic dieMechanic)
        {
            _tearApartDeathService = tearApartDeathService;
            _tearApartOnDeathMechanic = tearApartOnDeathMechanic;
            _dieMechanic = dieMechanic;
        }

        public void Initialize()
        {
            _tearApartDeathService.OnTearApart += _tearApartOnDeathMechanic.TearApartDeath;
            _tearApartDeathService.OnSimpleDeath += _dieMechanic.Die;
        }

        public void Dispose()
        {
            _tearApartDeathService.OnSimpleDeath -= _dieMechanic.Die;
            _tearApartDeathService.OnTearApart -= _tearApartOnDeathMechanic.TearApartDeath;
        }
    }
}