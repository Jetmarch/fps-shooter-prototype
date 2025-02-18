using FPSShooter.Game.Gameplay.Units.Installers;
using FPSShooter.Modules.Gameplay.Projectiles;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    public sealed class BulletProjectileInstaller : LifetimeScope
    {
        [SerializeField] private ProjectileConfig _projectileConfig;
        [SerializeField] private ProjectileView _projectileView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<BulletProjectilePresenter>(Lifetime.Scoped)
                .WithParameter(_projectileView)
                .WithParameter(_projectileConfig)
                .AsImplementedInterfaces();
            
            builder.Register<GameLoopController>(Lifetime.Scoped).AsImplementedInterfaces();
        }
    }
}