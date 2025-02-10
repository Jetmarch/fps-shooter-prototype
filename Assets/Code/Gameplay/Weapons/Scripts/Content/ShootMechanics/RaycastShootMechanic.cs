using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable, Obsolete]
    public sealed class RaycastShootMechanic : BaseShootMechanic
    {
        [ShowInInspector] private float _maxRayDistance = 100f;

        public override void Shoot(Transform shootPoint)
        {
            if (!CanShoot()) return;
            
            var ray = new Ray(shootPoint.position, shootPoint.forward);
            
            if (Physics.Raycast(ray, out var hit, _maxRayDistance))
            {
                //TODO: Send damage request
                Debug.Log($"Raycast Hit: {hit.collider.name}");
            }
            
            var newCurrentAmmo = Owner.CurrentAmmo - AmmoOnShot;
            Owner.SetCurrentAmmo(newCurrentAmmo);
        }
    }
}