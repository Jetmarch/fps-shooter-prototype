using Audio;
using FPSShooter.Core.Managers;
using FPSShooter.Core.Utils;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public sealed class GameSceneInstaller : LifetimeScope
    {
        [SerializeField] private WeaponPack _weaponPack;
        [SerializeField] private GameLoopManager _gameLoopManager;
        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private WeaponManager _weaponManager;
        [SerializeField] private ProjectileManager _projectileManager;
        [SerializeField] private ParticlesManager _particlesManager;
        [SerializeField] private Camera _camera;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gameLoopManager).AsImplementedInterfaces();
            builder.RegisterInstance(_weaponManager).AsImplementedInterfaces();;
            builder.RegisterInstance(_projectileManager).AsImplementedInterfaces();
            builder.RegisterInstance(_particlesManager).AsImplementedInterfaces();
            builder.RegisterInstance(_weaponPack);
            builder.RegisterInstance(_playerManager);
            builder.RegisterInstance(_camera);
            
            builder.Register<CursorToggler>(Lifetime.Scoped).AsImplementedInterfaces();
            
            builder.Register<AudioManager>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
