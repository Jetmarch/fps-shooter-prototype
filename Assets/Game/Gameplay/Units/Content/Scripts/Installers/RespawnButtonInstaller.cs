using FPSShooter.Game.Gameplay.Units.Player;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Impact;
using FPSShooter.Modules.Units;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Units
{
    public sealed class RespawnButtonInstaller : LifetimeScope
    {
        [SerializeField] private UnitView _view;
        [SerializeField] private ObjectState _objectState;
        
        [SerializeField] private Transform[] _respawnPositions;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UnitPresenter>(Lifetime.Scoped)
                .AsImplementedInterfaces();
            
            builder.Register<TargetDummyRespawner>(Lifetime.Scoped)
                .WithParameter(_respawnPositions)
                .AsSelf()
                .AsImplementedInterfaces();
            
            builder.Register<ImpactAffectMechanics>(Lifetime.Scoped)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<RespawnDummiesController>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
    }
}
