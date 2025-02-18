using FPSShooter.Game.Gameplay.Units.Installers;
using FPSShooter.Modules.Gameplay.Weapons;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Weapons
{
    public class PistolInstaller : LifetimeScope
    {
        [SerializeField] private WeaponConfig _pistolConfig;
        [SerializeField] private WeaponView _view;
        
        protected override void Configure(IContainerBuilder builder)
        {
            var pistolWeapon = _pistolConfig.CreateWeapon();
            builder.Register<ProjectileWeaponPresenter>(Lifetime.Scoped)
                .WithParameter(pistolWeapon)
                .WithParameter(_view)
                .AsImplementedInterfaces();
            
            builder.Register<GameLoopController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
    }
}