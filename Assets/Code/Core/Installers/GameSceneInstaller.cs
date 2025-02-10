using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.Units;
using FPSShooter.Gameplay.Weapons;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Core.Installers
{
    public class GameSceneInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<CursorToggler>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<PlayerManager>();
            builder.RegisterComponentInHierarchy<WeaponManager>();
            builder.RegisterComponentInHierarchy<GameLoopManager>();
            builder.RegisterComponentInHierarchy<Camera>();
        }
    }
}
