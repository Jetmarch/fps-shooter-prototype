using System;
using FPSShooter.Core.Managers;
using FPSShooter.Gameplay;
using FPSShooter.Gameplay.FPSCamera;
using FPSShooter.Gameplay.Units;
using FPSShooter.Gameplay.Utils;
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
        
        [Header("Weapons")]
        [SerializeField] private WeaponConfig _pistolConfig;
        [SerializeField] private WeaponView _pistolView;
        
        [Header("Utils")]
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _projectileParent;
        [SerializeField] private int _projectilePoolSize;
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureGameLoop(builder);
            ConfigurePlayer(builder);
            ConfigureCamera(builder);
            ConfigureWeapons(builder);
            
            builder.Register<CursorToggler>(Lifetime.Scoped).AsImplementedInterfaces();
            
            builder.Register<GameObjectPool>(Lifetime.Scoped)
                .WithParameter(_projectilePrefab)
                .WithParameter(_projectileParent)
                .WithParameter(_projectilePoolSize)
                .AsSelf()
                .AsImplementedInterfaces();
        }

        private void ConfigureWeapons(IContainerBuilder builder)
        {
            var pistolWeapon = _pistolConfig.CreateWeapon();
            // builder.RegisterInstance(pistolWeapon);
            // builder.RegisterInstance(_pistolView);

            builder.Register<ProjectileWeaponPresenter>(Lifetime.Scoped)
                .WithParameter(pistolWeapon)
                .WithParameter(_pistolView)
                .AsSelf()
                .AsImplementedInterfaces();
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
