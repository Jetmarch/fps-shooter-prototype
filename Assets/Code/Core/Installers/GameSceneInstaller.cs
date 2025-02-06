using FPSShooter.Core.Managers;
using FPSShooter.Gameplay;
using KinematicCharacterController;
using UnityEngine;
using UnityEngine.Serialization;
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
            
            builder.RegisterInstance(_gameLoopManager);
            
            ConfigurePlayer(builder);
        }

        private void ConfigurePlayer(IContainerBuilder builder)
        {
            builder.RegisterInstance(_player).AsSelf().AsImplementedInterfaces();
            builder.RegisterInstance(_movementData);
            
            builder.Register<MovementController>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
