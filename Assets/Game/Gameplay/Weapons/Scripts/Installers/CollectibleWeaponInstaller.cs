using FPSShooter.Modules.Utils;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Weapons
{
    public sealed class CollectibleWeaponInstaller : LifetimeScope
    {
        [SerializeField] private TriggerDetectorComponent _triggerDetectorComponent;
        [SerializeField] private string _weaponId;

        [SerializeField] private Transform _viewTransform;
        [SerializeField] private float _rotationSpeed;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<WeaponPickupController>(Lifetime.Scoped)
                .WithParameter(_triggerDetectorComponent)
                .WithParameter(_weaponId)
                .AsImplementedInterfaces();
        }
    }
}