using System;
using System.Collections.Generic;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Units;
using HomeworkSaveLoad.SaveSystem;
using UnityEngine;

namespace FPSShooter.Game.Core.SaveLoaders
{
    public sealed class PlayerData
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public List<string> Weapons;
    }
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerSaveLoader : SaveLoader<PlayerData, PlayerManager>
    {
        protected override void SetupData(PlayerManager service, PlayerData data)
        {
            var player = service.GetPlayer();
            SetupPlayer(player, data);
        }

        private void SetupPlayer(UnitView player, PlayerData data)
        {
            var fpsCharacterMechanic = player.GetMechanic<FPSCharacterMechanic>();
            if (fpsCharacterMechanic == null)
            {
                throw new NullReferenceException("PlayerSaveLoader: FPS Character Mechanic Not Found");
            }
            
            fpsCharacterMechanic.SetPosition(data.Position);
            fpsCharacterMechanic.SetRotation(data.Rotation);
            
            var weaponArsenalMechanic = player.GetMechanic<WeaponArsenalMechanic>();
            if (weaponArsenalMechanic == null)
            {
                throw new NullReferenceException("PlayerSaveLoader: Weapon Arsenal Mechanic Not Found");
            }
            weaponArsenalMechanic.RemoveAllWeapons();
            foreach (var weapon in data.Weapons)
            {
                weaponArsenalMechanic.TryAddWeapon(weapon);
                Debug.Log($"Loaded weapon {weapon}");
            }
        }

        protected override PlayerData ConvertToData(PlayerManager service)
        {
            var player = service.GetPlayer();

            var weaponArsenalMechanic = player.GetMechanic<WeaponArsenalMechanic>();
            if (weaponArsenalMechanic == null)
            {
                throw new NullReferenceException("PlayerSaveLoader: Weapon Arsenal Mechanic Not Found");
            }
            
            var weaponNames = new List<string>();
            var weaponList = weaponArsenalMechanic.GetWeapons();
            foreach (var weapon in weaponList)
            {
                var weaponName = weapon.GetWeaponName();
                weaponNames.Add(weaponName);
                Debug.Log($"Saved weapon {weaponName}");
            }
            
            return new PlayerData()
            {
                Position = player.transform.position,
                Rotation = player.transform.rotation.eulerAngles,
                Weapons = weaponNames
            };
        }
    }
}