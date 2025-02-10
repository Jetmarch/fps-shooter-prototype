using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Gameplay.Weapons.Installers
{
    public class PistolInstaller : LifetimeScope
    {
        [SerializeField] private WeaponConfig _pistolConfig;
        [SerializeField] private WeaponView _model;
        
        protected override void Configure(IContainerBuilder builder)
        {
            var pistolWeapon = _pistolConfig.CreateWeapon();
            builder.RegisterInstance(pistolWeapon);
            builder.RegisterInstance(_model);

            builder.Register<ProjectileWeaponPresenter>(Lifetime.Scoped)
                .WithParameter(pistolWeapon)
                .WithParameter(_model)
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}