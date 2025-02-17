using System.Collections.Generic;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;
using VContainer;

namespace FPSShooter.Modules.Gameplay.Weapons
{
    public sealed class WeaponManager : MonoBehaviour, IWeaponManager
    {
        [SerializeField] private List<WeaponView> _weaponPrefabs;
        private IGameLoopManager _gameLoopManager;

        [Inject]
        private void Configure(WeaponPack weaponPack, IGameLoopManager gameLoopManager)
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
