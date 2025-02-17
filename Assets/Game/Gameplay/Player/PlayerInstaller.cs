using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Movement;
using FPSShooter.Modules.Units;
using KinematicCharacterController;
using UnityEngine;
using UnityEngine.XR;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Gameplay.Units.Installers
{
    public class PlayerInstaller : LifetimeScope
    {
        [SerializeField] private PlayerConfig _config;
        
        [Header("Movement")]
        [SerializeField] private MovementParams _movementParams;
        
        [Header("Camera")]
        [SerializeField] private Transform _cameraTarget;
        
        [Header("Hands")]
        [SerializeField] private Transform _playerHands;

        [Header("Weapons")] 
        [SerializeField] private Transform _weaponParent;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<PlayerView>();
            ConfigureMovement(builder);
            ConfigureCamera(builder);
            ConfigureInput(builder);
            ConfigurePlayerHands(builder);

            builder.Register<DebugPlayerWeaponLoader>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureInput(IContainerBuilder builder)
        {
            builder.Register<PlayerInputObserver>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }

        private void ConfigureMovement(IContainerBuilder builder)
        {
            builder.Register<MovementController>(Lifetime.Scoped)
                .WithParameter(_config.MovementConfig)
                .WithParameter(_movementParams)
                .AsSelf()
                .AsImplementedInterfaces();
        }
        
        private void ConfigureCamera(IContainerBuilder builder)
        {
            builder.Register<FPSCameraController>(Lifetime.Scoped)
                .WithParameter(_config.FPSCameraSettings)
                .WithParameter(_cameraTarget)
                .AsSelf()
                .AsImplementedInterfaces();
        }

        private void ConfigurePlayerHands(IContainerBuilder builder)
        {
            builder.Register<PlayerHands>(Lifetime.Scoped)
                .WithParameter(_weaponParent);
            builder.Register<HandsFollowCameraLook>(Lifetime.Scoped)
                .WithParameter(_cameraTarget)
                .WithParameter(_config.HandsFollowCameraLookData);
            builder.Register<HandsWobbleAnimation>(Lifetime.Scoped)
                .WithParameter(_playerHands)
                .WithParameter(_config.HandsWobbleAnimationData);
            builder.Register<WeaponSwayEffect>(Lifetime.Scoped)
                .WithParameter(_weaponParent)
                .WithParameter(_config.WeaponSwayEffectData);
        }
    }
}