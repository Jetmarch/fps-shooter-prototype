using Audio;
using FPSShooter.Core.Managers;
using FPSShooter.Core.Utils;
using FPSShooter.Game.Core.SaveLoaders;
using FPSShooter.Game.Core.Tasks;
using FPSShooter.Game.Gameplay.Units;
using FPSShooter.Game.Meta.Upgrades.Scripts.Installers;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Core.Tasks;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Meta.Upgrades.Presenters;
using FPSShooter.Modules.Meta.Upgrades.UI;
using FPSShooter.Modules.Units;
using HomeworkSaveLoad.SaveSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class ShootingRangeSceneInstaller : LifetimeScope
    {
        [Header("Loading screen and tasks")]
        [SerializeField] private LoadingTaskConfig _loadingTaskConfig;
        [SerializeField] private Image _fadeImage;
        
        [Header("Managers")]
        [SerializeField] private GameLoopManager _gameLoopManager;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private WeaponManager _weaponManager;
        [SerializeField] private ProjectileManager _projectileManager;
        [SerializeField] private ParticlesManager _particlesManager;
        [SerializeField] private TargetDummyManager _targetDummyManager;
        [SerializeField] private SaveLoadManager _saveLoadManager;
        [SerializeField] private Camera _camera;
        
        [Header("Available weapons")]
        [SerializeField] private WeaponPack _weaponPack;
        
        [Header("Upgrades")]
        [SerializeField] private UpgradePanelList _upgradePanelList;
        [SerializeField] private Transform _panelContainer;
        [SerializeField] private UpgradePanel _panelPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureTasks(builder);
            ConfigureManagers(builder);
            ConfigureUI(builder);
            ConfigureCurrencyStorages(builder);
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
            builder.Register<AudioManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CursorToggler>(Lifetime.Singleton).AsSelf();
            
            ConfigureSaveLoad(builder);
        }

        private void ConfigureSaveLoad(IContainerBuilder builder)
        {
            builder.Register<VContainerGameContext>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            builder.RegisterInstance(_saveLoadManager);
            
            builder.Register<GameRepository>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            builder.Register<PlayerSaveLoader>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            builder.Register<TargetDummySaveLoader>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }

        private void ConfigureUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_fadeImage);
            
            ConfigureUpgradesUI(builder);
        }

        private void ConfigureCurrencyStorages(IContainerBuilder builder)
        {
            builder.Register<MoneyStorage>(Lifetime.Scoped).AsImplementedInterfaces();
        }
        
        private void ConfigureUpgradesUI(IContainerBuilder builder)
        {
            builder.RegisterInstance(_upgradePanelList);
            builder.Register<UpgradeListPresenter>(Lifetime.Scoped).AsImplementedInterfaces();

            builder.Register<UpgradePanelFactory>(Lifetime.Scoped)
                .WithParameter(_panelContainer)
                .WithParameter(_panelPrefab);
        }
    }
}
