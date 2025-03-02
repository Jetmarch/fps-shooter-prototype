using System;
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
    }
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class PlayerSaveLoader : SaveLoader<PlayerData, PlayerManager>
    {
        private const string PlayerPrefabPath = "Gameplay/Units/Content/Prefabs/[Player]";
        
        protected override void SetupData(PlayerManager playerManager, PlayerData data)
        {
            var player = playerManager.GetPlayer();
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
        }

        protected override PlayerData ConvertToData(PlayerManager playerManager)
        {
            var player = playerManager.GetPlayer();
            return new PlayerData()
            {
                Position = player.transform.position,
                Rotation = player.transform.rotation.eulerAngles,
            };
        }
    }
}