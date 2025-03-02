using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponArsenalMechanic : IUnitMechanic
    {
        private readonly WeaponContainer _weaponContainer;

        private bool _isEnabled;

        public WeaponArsenalMechanic(WeaponContainer weaponContainer)
        {
            _weaponContainer = weaponContainer;
            EnableUseWeapon();
        }
        
        public void Shoot()
        {
            if (!_isEnabled) return;
            _weaponContainer.ShootCurrentWeapon();
        }

        public void ShootStartAutomatic()
        {
            if (!_isEnabled) return;
            _weaponContainer.StartShootAutomaticCurrentWeapon();
        }

        public void ShootEndAutomatic()
        {
            if (!_isEnabled) return;
            _weaponContainer.EndShotAutomaticCurrentWeapon();
        }

        public void Reload()
        {
            if (!_isEnabled) return;
            _weaponContainer.ReloadCurrentWeapon();
        }

        public bool TryAddWeapon(IWeapon weapon)
        {
            return _weaponContainer.TryAddWeapon(weapon);
        }

        public void SetNextWeapon()
        {
            if (!_isEnabled) return;
            _weaponContainer.NextWeapon();
        }

        public void SetPreviousWeapon()
        {
            if (!_isEnabled) return;
            _weaponContainer.PreviousWeapon();
        }
        public void StopUpgrading()
        {
            _weaponContainer.StopUpgrading();
        }

        public void StartUpgrading()
        {
            _weaponContainer.StartUpgrading();
        }

        public IWeapon GetCurrentWeapon()
        {
            return _weaponContainer.GetCurrentWeapon();
        }

        public void EnableUseWeapon()
        {
            _isEnabled = true;
        }

        public void DisableUseWeapon()
        {
            _isEnabled = false;
        }
    }
}