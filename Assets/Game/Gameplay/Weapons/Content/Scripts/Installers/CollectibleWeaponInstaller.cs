using FPSShooter.Modules.Gameplay.Projectiles;
using FPSShooter.Modules.Utils;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Weapons
{
    public sealed class CollectibleWeaponInstaller : LifetimeScope
    {
        [SerializeField] private TriggerDetectorComponent _triggerDetectorComponent;
        [SerializeField] private string _weaponId;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<WeaponPickupController>(Lifetime.Scoped)
                .WithParameter(_triggerDetectorComponent)
                .WithParameter(_weaponId)
                .AsImplementedInterfaces();
        }
    }
}