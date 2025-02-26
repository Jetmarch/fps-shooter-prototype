using FPSShooter.Core.Managers;
using FPSShooter.Game.Gameplay.Impact;
using FPSShooter.Game.Gameplay.Units.Player;
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
            builder.Register<TargetDummyPresenter>(Lifetime.Scoped)
                .WithParameter(_view)
                .WithParameter(_objectState)
                .WithParameter(_hitParticle)
                .WithParameter(_viewAnimator)
                .AsImplementedInterfaces();

            builder.Register<DeathObserver>(Lifetime.Scoped)
                .WithParameter(_view)
                .AsImplementedInterfaces();
            
            builder.Register<TearingApartOnDeathMechanic>(Lifetime.Scoped)
                .WithParameter(_objectState)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterInstance(_collider);
        }
    }
}
