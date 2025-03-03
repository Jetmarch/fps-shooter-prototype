using FPSShooter.Game.Core.GameLoop;
using FPSShooter.Game.Gameplay.Units;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Meta.Upgrades;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Weapons
{
    public class ProjectileWeaponInstaller : LifetimeScope
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private WeaponView _view;
        
        [SerializeField] private TextMeshPro _ammoText;
        [SerializeField] private Animator _animator;

        [SerializeField] private UpgradeConfigBundle _upgradeConfigBundle;
        protected override void Configure(IContainerBuilder builder)
        {
            var projectileWeapon = _config.CreateWeapon();
            builder.RegisterInstance(projectileWeapon);
            
            builder.Register<ProjectileWeaponPresenter>(Lifetime.Scoped)
                .WithParameter(_view)
                .WithParameter(_animator)
                .AsImplementedInterfaces();
            
            builder.Register<GameLoopController>(Lifetime.Scoped)
                .AsImplementedInterfaces();

            builder.Register<HolographicAmmoDisplay>(Lifetime.Scoped)
                .WithParameter(_ammoText);

            ConfigureUpgrades(builder);
        }

        private void ConfigureUpgrades(IContainerBuilder builder)
        {
            builder.RegisterInstance(_upgradeConfigBundle);
            builder.Register<UpgradeFactory>(Lifetime.Scoped)
                .AsSelf();
            builder.Register<UpgradeWeaponMechanic>(Lifetime.Scoped)
                .AsSelf();
        }
    }
}