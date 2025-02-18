using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public sealed class WeaponManager : MonoBehaviour, IWeaponManager
    {
        [SerializeField] private List<WeaponView> _weaponPrefabs;

        [Inject]
        private void Configure(WeaponPack weaponPack)
        {
            _weaponPrefabs = weaponPack.GetWeapons();
        }

        public List<WeaponView> GetWeapons()
        {
            var weapons = new List<WeaponView>();
            foreach (var weaponPrefab in _weaponPrefabs)
            {
                var newWeapon = Instantiate(weaponPrefab, transform);
                weapons.Add(newWeapon);
            }
            return weapons;
        }
    }
}
