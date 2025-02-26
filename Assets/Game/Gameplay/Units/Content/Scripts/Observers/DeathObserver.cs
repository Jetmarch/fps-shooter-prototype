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
        private readonly TearApartDeathMechanic _tearApartDeathMechanic;
        private readonly DieResurrectMechanic _dieResurrectMechanic;

        public DeathObserver(TearApartDeathService tearApartDeathService, TearApartDeathMechanic tearApartDeathMechanic, DieResurrectMechanic dieResurrectMechanic)
        {
            _tearApartDeathService = tearApartDeathService;
            _tearApartDeathMechanic = tearApartDeathMechanic;
            _dieResurrectMechanic = dieResurrectMechanic;
        }

        public void Initialize()
        {
            _tearApartDeathService.OnTearApart += _tearApartDeathMechanic.TearApartDeath;
            _tearApartDeathService.OnSimpleDeath += _dieResurrectMechanic.Die;
        }

        public void Dispose()
        {
            _tearApartDeathService.OnSimpleDeath -= _dieResurrectMechanic.Die;
            _tearApartDeathService.OnTearApart -= _tearApartDeathMechanic.TearApartDeath;
        }
    }
}