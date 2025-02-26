using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    [Serializable]
    public sealed class WeaponContainer
    {
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private int _currentWeaponIndex;
        private IWeapon _currentWeapon;
        private List<IWeapon> _weapons;

        public WeaponContainer(Transform weaponParent)
        {
            _weaponParent = weaponParent;
            _weapons = new List<IWeapon>();
        }
        
        public void ShootCurrentWeapon()
        {
            _currentWeapon.RequestShoot();
        }

        public void StartShootAutomaticCurrentWeapon()
        {
            _currentWeapon.RequestStartAutomaticShoot();
        }

        public void EndShotAutomaticCurrentWeapon()
        {
            _currentWeapon.RequestEndAutomaticShoot();
        }

        public void ReloadCurrentWeapon()
        {
            _currentWeapon.RequestReload();
        }
        
        public void AddWeapon(IWeapon weapon)
        {
            if (_weapons.Contains(weapon)) return;
            _weapons.Add(weapon);
            SetCurrentWeapon(weapon);
        }
        
        public void NextWeapon()
        {
            _currentWeapon.PutAway();
            _currentWeaponIndex++;
            if (_currentWeaponIndex > _weapons.Count - 1)
            {
                _currentWeaponIndex = 0;
            }
            
            SetCurrentWeapon(_currentWeaponIndex);
        }
        
        public void PreviousWeapon()
        {
            _currentWeapon.PutAway();
            _currentWeaponIndex--;
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = _weapons.Count - 1;
            }

            SetCurrentWeapon(_currentWeaponIndex);
        }
        
        private void SetCurrentWeapon(int weaponIndex)
        {
            if (weaponIndex >= _weapons.Count || weaponIndex < 0) return;

            PrepareNewWeapon(_weapons[weaponIndex]);
        }
        
        private void SetCurrentWeapon(IWeapon weapon)
        {
            if (!_weapons.Contains(weapon)) return;
            _currentWeaponIndex = _weapons.IndexOf(weapon);
            PrepareNewWeapon(weapon);
        }
        
        private void PrepareNewWeapon(IWeapon weapon)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.SetActive(false);
            }
            _currentWeapon = weapon;
            _currentWeapon.SetActive(true);
            _currentWeapon.Position = _weaponParent.position;
            _currentWeapon.Rotation = _weaponParent.rotation;
            weapon.SetParent(_weaponParent);
            weapon.PullOut();
        }
    }
}