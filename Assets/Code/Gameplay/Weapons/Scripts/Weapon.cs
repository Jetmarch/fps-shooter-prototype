using System;
using FPSShooter.Gameplay.Projectiles;
using FPSShooter.Gameplay.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public class Weapon
    {
        [SerializeField] private BaseItemMetadata _itemMetadata;
        [SerializeField] private uint _maxAmmo;
        [SerializeField] private uint _currentAmmo;
        [SerializeField] private float _shootDelay;
        [SerializeField] private float _reloadDuration;
        [SerializeReference] private BaseReloadMechanic _reloadMechanic;
        [SerializeField] private Projectile _projectilePrefab;
        
        public BaseItemMetadata ItemMetadata => _itemMetadata;
        public uint MaxAmmo => _maxAmmo;
        public uint CurrentAmmo => _currentAmmo;
        public float ShootDelay => _shootDelay;
        public float ReloadDuration => _reloadDuration;
        public BaseReloadMechanic ReloadMechanic => _reloadMechanic;
        public Projectile ProjectilePrefab => _projectilePrefab;

        public Weapon(Weapon weapon)
        {
            _itemMetadata = new BaseItemMetadata(weapon.ItemMetadata);
            _maxAmmo = weapon.MaxAmmo;
            _currentAmmo = weapon.CurrentAmmo;
            _shootDelay = weapon.ShootDelay;
            _reloadDuration = weapon.ReloadDuration;
            _reloadMechanic = weapon.ReloadMechanic;
            _projectilePrefab = weapon.ProjectilePrefab;

            _reloadMechanic.SetOwner(this);
        }

        public bool CanShoot()
        {
            return _currentAmmo > 0;
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