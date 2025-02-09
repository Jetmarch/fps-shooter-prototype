using System;
using FPSShooter.Core.Managers;
using FPSShooter.Gameplay;
using FPSShooter.Gameplay.FPSCamera;
using FPSShooter.Gameplay.Weapons;
using FPSShooter.Observers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public class GameSceneInstaller : LifetimeScope
    {
        [Header("System")]
        [SerializeField] private GameLoopManager _gameLoopManager;
        
        [Header("Player")]
        [SerializeField] private Player _player;
        [SerializeField] private MovementData _movementData;
        
        [Header("Camera")]
        [SerializeField] private Camera _camera;
        [SerializeField] private FPSCameraSettings _fpsCameraSettings;
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureGameLoop(builder);
            ConfigurePlayer(builder);
            ConfigureCamera(builder);
            
            builder.Register<CursorToggler>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void ConfigureGameLoop(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameLoopManager);
        }

        private void ConfigurePlayer(IContainerBuilder builder)
        {
            builder.RegisterInstance(_player)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<MovementController>(Lifetime.Scoped)
                .WithParameter(_movementData)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<PlayerInputObserver>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
        
        private void ConfigureCamera(IContainerBuilder builder)
        {
            builder.RegisterInstance(_camera);
            builder.Register<FPSCameraController>(Lifetime.Scoped)
                .WithParameter(_fpsCameraSettings)
                .AsSelf()
                .AsImplementedInterfaces();
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            _camera = Camera.main;
        }
#endif
    }
}
