using System;
using FPSShooter.Core.Utils;
using FPSShooter.Gameplay.Projectiles;
using FPSShooter.Gameplay.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public class Weapon
    {
        [SerializeField] private BaseItemMetadata _itemMetadata;
        [SerializeField] private ClampedIntValue _ammo;
        [SerializeField] private ClampedFloatValue _shootDelay;
        [SerializeField] private ClampedFloatValue _reloadDelay;
        [SerializeReference] private BaseReloadMechanic _reloadMechanic;
        [SerializeField] private bool _isAutomatic;
        [SerializeField] private ProjectileType _projectileType;
        
        public BaseItemMetadata ItemMetadata => _itemMetadata;
        public int MaxAmmo => _ammo.MaxValue;
        public int CurrentAmmo => _ammo.CurrentValue;
        public ClampedIntValue Ammo => _ammo;
        public ClampedFloatValue ShootDelay => _shootDelay;
        public ClampedFloatValue ReloadDelay => _reloadDelay;
        public BaseReloadMechanic ReloadMechanic => _reloadMechanic;
        public ProjectileType ProjectileType => _projectileType;

        public Weapon(Weapon weapon)
        {
            _itemMetadata = new BaseItemMetadata(weapon.ItemMetadata);
            _ammo = new ClampedIntValue(weapon.Ammo);
            _shootDelay = new ClampedFloatValue(weapon.ShootDelay);
            _reloadDelay = new ClampedFloatValue(weapon.ReloadDelay);
            _reloadMechanic = weapon.ReloadMechanic;
            _projectileType = weapon.ProjectileType;

            _reloadMechanic.SetOwner(this);
        }

        public bool NeedToReload()
        {
            return _ammo.CurrentValue <= _ammo.MinValue;
        }

        public bool IsDelayBetweenShots()
        {
            return _shootDelay.CurrentValue > _shootDelay.MinValue;
        }

        public bool IsReloading()
        {
            return _reloadDelay.CurrentValue > _reloadDelay.MinValue;
        }

        public bool TryReload()
        {
            if(!_reloadMechanic.CanReload()) return false;
            Debug.Log("Reloading");
            _reloadMechanic.Reload();
            _reloadDelay.CurrentValue = _reloadDelay.MaxValue;
            return true;
        }

        public void SetCurrentAmmo(int ammo)
        {
            _ammo.CurrentValue = ammo;
        }

        //TODO: rename it
        public void SetShootDelay()
        {
            _shootDelay.CurrentValue = _shootDelay.MaxValue;
        }

        public void UpdateShootDelay(float deltaTime)
        {
            if (_shootDelay.CurrentValue > _shootDelay.MinValue)
            {
                _shootDelay.CurrentValue -= deltaTime;
            }
        }

        public void UpdateReloadDelay(float deltaTime)
        {
            if (_reloadDelay.CurrentValue > _reloadDelay.MinValue)
            {
                _reloadDelay.CurrentValue -= deltaTime;
            }
        }

        public Weapon Clone()
        {
            return new Weapon(this);
        }
    }
}