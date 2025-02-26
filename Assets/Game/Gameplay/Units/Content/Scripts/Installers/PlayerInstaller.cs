using FPSShooter.Game.Core.GameLoop;
using FPSShooter.Game.Gameplay.Units.Player;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.FPSCamera;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Movement;
using FPSShooter.Modules.Units;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units.Installers
{
    public sealed class PlayerInstaller : LifetimeScope
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private UnitView _view;
        
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
            ConfigureMovement(builder);
            ConfigureCamera(builder);
            ConfigureInput(builder);
            ConfigurePlayerHands(builder);
            
            ConfigureMechanics(builder);
            
            builder.Register<UnitPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<GameLoopController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<DebugPlayerWeaponLoader>(Lifetime.Scoped)
                .WithParameter(_view)
                .AsImplementedInterfaces();
        }

        private void ConfigureInput(IContainerBuilder builder)
        {
            builder.Register<PlayerMoveInputObserver>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<PlayerWeaponInputObserver>(Lifetime.Scoped)
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
            builder.Register<WeaponContainer>(Lifetime.Scoped)
                .WithParameter(_weaponParent);
            builder.Register<HandsFollowCameraLook>(Lifetime.Scoped)
                .WithParameter(_cameraTarget)
                .AsImplementedInterfaces();
            
            builder.Register<HandsWobbleAnimation>(Lifetime.Scoped)
                .WithParameter(_playerHands)
                .WithParameter(_config.HandsWobbleAnimationData);
            builder.Register<HandsWobbleController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            
            builder.Register<WeaponSwayEffect>(Lifetime.Scoped)
                .WithParameter(_weaponParent)
                .WithParameter(_config.WeaponSwayEffectData)
                .AsSelf()
                .AsImplementedInterfaces();
            builder.Register<WeaponSwayController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
        
        private void ConfigureMechanics(IContainerBuilder builder)
        {
            builder.Register<FirstPersonCharacterMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<WeaponArsenalMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}