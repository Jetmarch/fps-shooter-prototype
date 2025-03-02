using System;
using FPSShooter.Game.Gameplay.Units.UnitLogic;
using FPSShooter.Modules.Gameplay.Weapons;
using FPSShooter.Modules.Units;
using FPSShooter.Modules.Utils;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Weapons
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class WeaponPickupController : IInitializable, IDisposable
    {
        private readonly WeaponManager _weaponManager;
        private readonly TriggerDetectorComponent _triggerDetectorComponent;
        private readonly string _weaponId;

        public WeaponPickupController(WeaponManager weaponManager, TriggerDetectorComponent triggerDetectorComponent, string weaponId)
        {
            _weaponManager = weaponManager;
            _triggerDetectorComponent = triggerDetectorComponent;
            _weaponId = weaponId;
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
            var weapon = _weaponManager.GetWeapon(_weaponId);

            if (weaponArsenal.TryAddWeapon(weapon))
            {
                UnityEngine.Object.Destroy(_triggerDetectorComponent.gameObject);
            }
        }
    }
}