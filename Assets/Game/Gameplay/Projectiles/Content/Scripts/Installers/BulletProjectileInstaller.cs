using FPSShooter.Game.Core.GameLoop;
using FPSShooter.Game.Gameplay.Units.Player;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    public sealed class BulletProjectileInstaller : LifetimeScope
    {
        [SerializeField] private UnitView _unitView;
        [SerializeField] private ProjectileConfig _projectileConfig;
        [SerializeField] private CollisionDetectorComponent _collisionDetectorComponent;
        [SerializeField] private Rigidbody _rigidbody;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_projectileConfig);
            builder.RegisterInstance(_collisionDetectorComponent);
            builder.RegisterInstance(_rigidbody);
            builder.RegisterInstance(_unitView);
            
            builder.Register<UnitPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<SoundPlayer>(Lifetime.Scoped)
                .AsSelf();
            
            ConfigureMechanics(builder);
            ConfigureControllers(builder);
        }

        private void ConfigureMechanics(IContainerBuilder builder)
        {
            builder.Register<BallisticMoveMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<ProjectileAffectTargetMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<ProjectileDestroyMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<ProjectileMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
        }
        
        private void ConfigureControllers(IContainerBuilder builder)
        {
            builder.Register<DestroyOnAffectTargetController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<ProjectileCollisionController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<GameLoopController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
    }
}