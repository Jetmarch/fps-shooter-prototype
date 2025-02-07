using FPSShooter.Core.Managers;
using FPSShooter.Gameplay;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureGameLoop(builder);
            
            ConfigurePlayer(builder);
        }
        
        private void ConfigureGameLoop(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameLoopManager);
        }

        private void ConfigurePlayer(IContainerBuilder builder)
        {
            builder.RegisterInstance(_player).AsSelf().AsImplementedInterfaces();
            builder.RegisterInstance(_movementData);
            
            builder.Register<MovementController>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerInputObserver>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
