using System;
using FPSShooter.Gameplay.Projectiles;
using UnityEngine;

namespace FPSShooter.Gameplay.Weapons
{
    [Serializable, Obsolete]
    public sealed class ProjectileShootMechanic : BaseShootMechanic
    {
        [SerializeField] private ProjectileType _projectileType;
        
        public override void Shoot(Transform shootPoint)
        {
            //TODO: Send request for projectile creating
            //ProjectileManager will take that request and handle it
            //OnProjectileShoot?.Invoke(shootPoint, _projectileType, new DamageRequest());
        }
    }
}