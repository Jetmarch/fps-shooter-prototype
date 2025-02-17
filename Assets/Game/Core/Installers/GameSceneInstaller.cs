using FPSShooter.Core.Managers;
using FPSShooter.Core.Utils;
using FPSShooter.Gameplay.Projectiles;
using FPSShooter.Gameplay.Units;
using FPSShooter.Gameplay.Weapons;
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
            builder.RegisterInstance(_weaponPack);
            builder.RegisterInstance(_gameLoopManager);
            builder.RegisterInstance(_playerManager);
            builder.RegisterInstance(_weaponManager);
            builder.RegisterInstance(_projectileManager).AsImplementedInterfaces();
            builder.RegisterInstance(_particlesManager);
            builder.RegisterInstance(_camera);
            
            builder.Register<CursorToggler>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}
