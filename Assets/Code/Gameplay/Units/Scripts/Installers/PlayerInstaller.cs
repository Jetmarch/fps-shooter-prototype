using FPSShooter.Gameplay.FPSCamera;
using FPSShooter.Observers;
using UnityEngine;
using UnityEngine.XR;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Gameplay.Units.Installers
{
    public class PlayerInstaller : LifetimeScope
    {
        [Header("Movement")]
        [SerializeField] private MovementData _movementData;
        
        [Header("Camera")]
        [SerializeField] private FPSCameraSettings _fpsCameraSettings;
        [SerializeField] private Transform _cameraTarget;
        
        [Header("Hands")]
        [SerializeField] private float _handsFollowSpeed = 25f;
        [SerializeField] private Transform _playerHands;
        
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
                .WithParameter(_movementData)
                .AsSelf()
                .AsImplementedInterfaces();
        }
        
        private void ConfigureCamera(IContainerBuilder builder)
        {
            builder.Register<FPSCameraController>(Lifetime.Scoped)
                .WithParameter(_fpsCameraSettings)
                .WithParameter(_cameraTarget)
                .AsSelf()
                .AsImplementedInterfaces();
        }

        private void ConfigurePlayerHands(IContainerBuilder builder)
        {
            builder.Register<HandsFollowCameraLook>(Lifetime.Scoped)
                .WithParameter(_cameraTarget)
                .WithParameter(_handsFollowSpeed);
            builder.Register<HandsWobbleAnimation>(Lifetime.Scoped)
                .WithParameter(_playerHands);
        }
    }
}