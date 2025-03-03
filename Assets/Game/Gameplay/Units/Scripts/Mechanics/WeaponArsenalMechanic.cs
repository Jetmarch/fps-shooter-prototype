using System;
using System.Collections.Generic;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;

namespace FPSShooter.Game.Gameplay.Units.UnitLogic
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponArsenalMechanic : IUnitMechanic
    {
        private readonly WeaponContainer _weaponContainer;
        private readonly WeaponManager _weaponManager;

        private bool _isEnabled;

        public WeaponArsenalMechanic(WeaponContainer weaponContainer, WeaponManager weaponManager)
        {
            _weaponContainer = weaponContainer;
            _weaponManager = weaponManager;
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

        public bool TryAddWeapon(string weaponName)
        {
            var weapon = _weaponManager.GetWeapon(weaponName);
            if (weapon == null)
            {
                throw new NullReferenceException($"WeaponArsenalMechanic: Cannot find weapon with name {weaponName}");
            }
            return _weaponContainer.TryAddWeapon(weapon);
        }

        public void RemoveWeapon(string weaponName)
        {
            _weaponContainer.RemoveWeapon(weaponName);
        }
        
        public void RemoveAllWeapons()
        {
            _weaponContainer.RemoveAllWeapons();
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

        public List<IWeapon> GetWeapons()
        {
            return _weaponContainer.GetWeapons();
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