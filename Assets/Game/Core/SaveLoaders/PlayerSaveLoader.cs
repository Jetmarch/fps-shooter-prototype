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
        }

        protected override PlayerData ConvertToData(PlayerManager service)
        {
            var player = service.GetPlayer();
            return new PlayerData()
            {
                Position = player.transform.position,
                Rotation = player.transform.rotation.eulerAngles,
            };
        }
    }
}