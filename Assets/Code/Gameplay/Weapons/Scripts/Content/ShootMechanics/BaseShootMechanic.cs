using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable, Obsolete]
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
}