using System.Collections.Generic;
using FPSShooter.Core.Managers;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Weapons
{
    public sealed class WeaponManager : MonoBehaviour
    {
        [SerializeField] private List<WeaponView> _weaponPrefabs;
        [SerializeField] private GameLoopManager _gameLoopManager;

        [Inject]
        private void Configure(WeaponPack weaponPack, GameLoopManager gameLoopManager)
        {
            _weaponPrefabs = weaponPack.GetWeapons();
            _gameLoopManager = gameLoopManager;
        }

        public List<WeaponView> GetWeapons()
        {
            var weapons = new List<WeaponView>();
            foreach (var weaponPrefab in _weaponPrefabs)
            {
                var newWeapon = Instantiate(weaponPrefab, transform);
                weapons.Add(newWeapon);
                _gameLoopManager.AddListener(newWeapon);
            }
            return weapons;
        }
    }
}
