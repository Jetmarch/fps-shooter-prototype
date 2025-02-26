using FPSShooter.Core.Managers;
using FPSShooter.Game.Gameplay.Impact;
using FPSShooter.Game.Gameplay.Units.Player;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units.Installers
{
    public sealed class TargetDummyInstaller : LifetimeScope
    {
        [SerializeField] private UnitView _view;
        [SerializeField] private ObjectState _objectState;
        [SerializeField] private Animator _viewAnimator;
        [SerializeField] private Collider _collider;
        [SerializeField] private ParticleType _hitParticle;
        [SerializeField] private ParticleType _tearApartParticle;
        [SerializeField] private ParticleType _deathParticle;
        [SerializeField] private ParticleType _resurrectParticle;
        
        //TODO: DummyConfig
        //TODO: TearApartDeathConfig
        
        protected override void Configure(IContainerBuilder builder)
        {
            _objectState.Initialize();
            builder.RegisterInstance(_view);
            builder.RegisterInstance(_collider);
            builder.RegisterInstance(_objectState);
            builder.RegisterInstance(_viewAnimator);
            
            builder.Register<UnitPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<TearApartDeathService>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            ConfigureMechanics(builder);
            ConfigureControllers(builder);
        }


        private void ConfigureMechanics(IContainerBuilder builder)
        {
            builder.Register<ObjectStateMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<DieMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<ResurrectMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<TearApartOnDeathMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<ImpactAffectMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<HitMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
        }
        
        private void ConfigureControllers(IContainerBuilder builder)
        {
            builder.Register<DeathObserver>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<HitMechanicController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
    }
}
