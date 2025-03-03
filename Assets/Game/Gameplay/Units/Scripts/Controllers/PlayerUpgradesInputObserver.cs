using System;
using FPSShooter.Core.Systems;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerUpgradesInputObserver : IInitializable, IDisposable
    {
        private readonly IInputSystem _inputSystem;
        private readonly UpgradeWeaponMechanic _upgradeWeaponMechanic;

        public PlayerUpgradesInputObserver(IInputSystem inputSystem, UpgradeWeaponMechanic upgradeWeaponMechanic)
        {
            _inputSystem = inputSystem;
            _upgradeWeaponMechanic = upgradeWeaponMechanic;
        }

        public void Initialize()
        {
            _inputSystem.OnUpgrades += _upgradeWeaponMechanic.ToggleUpgradeState;
        }

        public void Dispose()
        {
            _inputSystem.OnUpgrades -= _upgradeWeaponMechanic.ToggleUpgradeState;
        }
    }
}