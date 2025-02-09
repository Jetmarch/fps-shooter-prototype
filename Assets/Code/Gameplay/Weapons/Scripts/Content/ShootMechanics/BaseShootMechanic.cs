using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable]
    public abstract class BaseShootMechanic
    {
        [ShowInInspector] protected uint AmmoOnShot = 1;
        
        protected Weapon Owner;
        public virtual bool CanShoot()
        {
            return Owner.CurrentAmmo - AmmoOnShot > 0;
        }
        public abstract void Shoot(Transform shootPoint);

        public void SetOwner(Weapon owner)
        {
            Owner = owner;
        }
    }

    [Serializable]
    public sealed class RaycastShootMechanic : BaseShootMechanic
    {
        [ShowInInspector] private float _maxRayDistance = 100f;

        public override void Shoot(Transform shootPoint)
        {
            if (!CanShoot()) return;
            
            var ray = new Ray(shootPoint.position, shootPoint.forward);
            
            if (Physics.Raycast(ray, out var hit, _maxRayDistance))
            {
                Debug.Log($"Raycast Hit: {hit.collider.name}");
            }
            
            var newCurrentAmmo = Owner.CurrentAmmo - AmmoOnShot;
            Owner.SetCurrentAmmo(newCurrentAmmo);
        }
    }

    [Serializable]
    public sealed class ProjectileShootMechanic : BaseShootMechanic
    {
        public override void Shoot(Transform shootPoint)
        {
            
        }
    }
}