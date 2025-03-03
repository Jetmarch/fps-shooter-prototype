using System;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Units;
using FPSShooter.Modules.Utils;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponPickupController : IInitializable, IDisposable
    {
        private readonly TriggerDetectorComponent _triggerDetectorComponent;
        private readonly string _weaponName;

        public WeaponPickupController(TriggerDetectorComponent triggerDetectorComponent, string weaponName)
        {
            _triggerDetectorComponent = triggerDetectorComponent;
            _weaponName = weaponName;
        }

        public void Initialize()
        {
            _triggerDetectorComponent.TriggerEnter += AddWeaponToUnit;
        }
        
        public void Dispose()
        {
            _triggerDetectorComponent.TriggerEnter -= AddWeaponToUnit;
        }
        
        private void AddWeaponToUnit(Collider obj)
        {
            var unitView = obj.gameObject.GetComponent<UnitView>();
            if (!unitView) return;
            var weaponArsenal = unitView.GetMechanic<WeaponArsenalMechanic>();
            if (weaponArsenal == null) return;

            if (weaponArsenal.TryAddWeapon(_weaponName))
            {
                //TODO: fix bug with removing inputSystem from gameLoop 
                UnityEngine.Object.Destroy(_triggerDetectorComponent.gameObject);
            }
        }
    }
}