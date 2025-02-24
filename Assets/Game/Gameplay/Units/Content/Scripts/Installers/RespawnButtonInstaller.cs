
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
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<RespawnButtonPresenter>(Lifetime.Scoped)
                .WithParameter(_view)
                .WithParameter(_objectState)
                .AsImplementedInterfaces();
        }
    }
}
