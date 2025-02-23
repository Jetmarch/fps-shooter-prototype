using FPSShooter.Game.Core.GameLoop;
using FPSShooter.Modules.Gameplay.Weapons;
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            var pistolWeapon = _config.CreateWeapon();
            builder.Register<ProjectileWeaponPresenter>(Lifetime.Scoped)
                .WithParameter(pistolWeapon)
                .WithParameter(_view)
                .AsImplementedInterfaces();
            
            builder.Register<GameLoopController>(Lifetime.Scoped)
                .AsImplementedInterfaces();

            builder.Register<HolographicAmmoDisplay>(Lifetime.Scoped)
                .WithParameter(_ammoText);
        }
    }
}