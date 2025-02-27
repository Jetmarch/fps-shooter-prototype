using System;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public interface IProjectileManager
    {
        public event Action<GameObject> OnProjectileHitObject;
        GameObject CreateProjectile(ProjectileType type, Transform shootPoint);
    }
}