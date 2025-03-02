using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public sealed class WeaponManager : MonoBehaviour, IWeaponManager, IInitializable
    {
        private Dictionary<string, WeaponView> _weaponPrefabs;
        private WeaponPack _weaponPack;

        [Inject]
        private void Configure(WeaponPack weaponPack)
        {
            _weaponPack = weaponPack;
        }
        
        public void Initialize()
        {
            PrepareWeapons(_weaponPack);
        }

        private void PrepareWeapons(WeaponPack weaponPack)
        {
            _weaponPrefabs = new Dictionary<string, WeaponView>();
            foreach (var weaponKeyValue in weaponPack.GetWeapons())
            {
                var newWeapon = Instantiate(weaponKeyValue.Value, transform);
                _weaponPrefabs[weaponKeyValue.Key] = newWeapon;
            }
        }

        public Dictionary<string, WeaponView> GetWeapons()
        {
            return _weaponPrefabs;
        }

        public WeaponView GetWeapon(string key)
        {
            return _weaponPrefabs[key];
        }
    }
}
