using System;
using FPSShooter.Core.Systems;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerUpgradesInputObserver : IInitializable, IDisposable
    {
        private readonly IInputSystem _inputSystem;
        private readonly UpgradeMechanic _upgradeMechanic;

        public PlayerUpgradesInputObserver(IInputSystem inputSystem, UpgradeMechanic upgradeMechanic)
        {
            _inputSystem = inputSystem;
            _upgradeMechanic = upgradeMechanic;
        }

        public void Initialize()
        {
            _inputSystem.OnUpgrades += _upgradeMechanic.ToggleUpgradeState;
        }

        public void Dispose()
        {
            _inputSystem.OnUpgrades -= _upgradeMechanic.ToggleUpgradeState;
        }
    }
}