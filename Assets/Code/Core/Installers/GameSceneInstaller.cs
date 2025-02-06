using FPSShooter.Core.Managers;
using FPSShooter.Gameplay;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_player).AsSelf().AsImplementedInterfaces();
            builder.RegisterInstance(_gameLoopManager);
        }
    }
}
