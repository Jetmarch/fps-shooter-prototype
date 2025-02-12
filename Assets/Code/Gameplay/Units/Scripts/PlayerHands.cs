using System;
using System.Collections.Generic;
using FPSShooter.Gameplay.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Gameplay.Units
{
    [Serializable]
    public sealed class PlayerHands
    {
        [SerializeField] private Transform _weaponParent;
        [ShowInInspector] private List<IWeapon> _weapons = new();
        [ShowInInspector] private IWeapon _currentWeapon;
        [SerializeField] private int _currentWeaponIndex;
        
        public void Shoot()
        {
            _currentWeapon.RequestShoot();
        }
        
        public void AddWeapon(IWeapon weapon)
        {
            if (_weapons.Contains(weapon)) return;
            _weapons.Add(weapon);
            SetCurrentWeapon(weapon);
        }
        
        public void NextWeapon()
        {
            _currentWeaponIndex++;
            if (_currentWeaponIndex > _weapons.Count - 1)
            {
                _currentWeaponIndex = 0;
            }
            
            SetCurrentWeapon(_currentWeaponIndex);
        }
        
        public void PreviousWeapon()
        {
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
        }
        
        
    }
}