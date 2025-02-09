using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public class Weapon
    {
        [ShowInInspector] private BaseItemMetadata _itemMetadata;
        [ShowInInspector] private uint _maxAmmo = 100;
        [ShowInInspector] private uint _currentAmmo = 100;
        [ShowInInspector] private float _shootDelay = 0.5f;
        [ShowInInspector] private float _reloadDuration = 0.7f;
        [SerializeReference] private BaseReloadMechanic _reloadMechanic;
        [SerializeReference] private BaseShootMechanic _shootMechanic;
        
        public BaseItemMetadata ItemMetadata => _itemMetadata;
        public uint MaxAmmo => _maxAmmo;
        public uint CurrentAmmo => _currentAmmo;
        public float ShootDelay => _shootDelay;
        public float ReloadDuration => _reloadDuration;
        public BaseReloadMechanic ReloadMechanic => _reloadMechanic;
        public BaseShootMechanic ShootMechanic => _shootMechanic;

        public Weapon(Weapon weapon)
        {
            _itemMetadata = new BaseItemMetadata(weapon.ItemMetadata);
            _maxAmmo = weapon.MaxAmmo;
            _currentAmmo = weapon.CurrentAmmo;
            _shootDelay = weapon.ShootDelay;
            _reloadDuration = weapon.ReloadDuration;
            _reloadMechanic = weapon.ReloadMechanic;
            _shootMechanic = weapon.ShootMechanic;

            _reloadMechanic.SetOwner(this);
            _shootMechanic.SetOwner(this);
        }

        public bool TryShoot(Transform shootPoint)
        {
            if (!_shootMechanic.CanShoot()) return false;
            _shootMechanic.Shoot(shootPoint);
            return true;
        }

        public bool TryReload()
        {
            if(!_reloadMechanic.CanReload()) return false;
            _reloadMechanic.Reload();
            return true;
        }

        public void SetCurrentAmmo(uint ammo)
        {
            _currentAmmo = ammo;
        }

        public Weapon Clone()
        {
            return new Weapon(this);
        }
    }
}