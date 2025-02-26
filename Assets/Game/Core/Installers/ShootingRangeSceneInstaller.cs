using Audio;
using FPSShooter.Core.Managers;
using FPSShooter.Core.Utils;
using FPSShooter.Game.Core.Tasks;
using FPSShooter.Game.Gameplay.Units;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Core.Tasks;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class ShootingRangeSceneInstaller : LifetimeScope
    {
        
        [SerializeField] private LoadingTaskConfig _loadingTaskConfig;
        [SerializeField] private Image _fadeImage;
        
        [SerializeField] private WeaponPack _weaponPack;
        [SerializeField] private GameLoopManager _gameLoopManager;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private WeaponManager _weaponManager;
        [SerializeField] private ProjectileManager _projectileManager;
        [SerializeField] private ParticlesManager _particlesManager;
        [SerializeField] private TargetDummyManager _targetDummyManager;
        [SerializeField] private Camera _camera;

        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureTasks(builder);
            ConfigureManagers(builder);
            ConfigureUI(builder);
        }
        
        private void ConfigureTasks(IContainerBuilder builder)
        {
            builder.Register<TaskRunner>(Lifetime.Singleton)
                .WithParameter(_loadingTaskConfig);

            builder.Register<TaskRunnerController>(Lifetime.Singleton).AsImplementedInterfaces();
        }
        
        private void ConfigureManagers(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameLoopManager).AsImplementedInterfaces();
            builder.RegisterInstance(_weaponManager).AsImplementedInterfaces();
            builder.RegisterInstance(_projectileManager).AsImplementedInterfaces();
            builder.RegisterInstance(_particlesManager).AsImplementedInterfaces();
            builder.RegisterInstance(_weaponPack);
            builder.RegisterInstance(_playerManager);
            builder.RegisterInstance(_targetDummyManager);
            builder.RegisterInstance(_camera);
            
            
            builder.Register<CursorToggler>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<AudioManager>(Lifetime.Singleton).AsImplementedInterfaces();
        }
        
        private void ConfigureUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_fadeImage);
        }
    }
}
