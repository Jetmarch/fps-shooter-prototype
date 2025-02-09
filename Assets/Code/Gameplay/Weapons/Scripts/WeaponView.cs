using System;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    public sealed class WeaponView : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private Transform _shootPoint;

        [SerializeField] private Weapon _weapon;

        private void Start()
        {
            _weapon = _weaponConfig.GetClone();
        }

        public void Shoot()
        {
            _weapon.TryShoot(_shootPoint);
        }
        
        public void Reload()
        {
            _weapon.TryReload();
        }
    }
}
