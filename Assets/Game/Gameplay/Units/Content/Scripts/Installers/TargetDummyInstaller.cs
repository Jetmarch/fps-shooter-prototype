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
        [SerializeField] private ParticleType _hitParticle;
        [SerializeField] private Animator _viewAnimator;
        [SerializeField] private Collider _collider;
        
        //TODO: DummyConfig
        //TODO: TearApartDeathConfig
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UnitPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<DieResurrectMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<TearApartDeathMechanic>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<TearApartDeathService>(Lifetime.Scoped)
                .WithParameter(_objectState)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<DeathObserver>(Lifetime.Scoped)
                .AsImplementedInterfaces();

            builder.RegisterInstance(_collider);
        }
    }
}
