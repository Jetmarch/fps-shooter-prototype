using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public interface IProjectileManager
    {
        Projectile CreateProjectile(Transform shootPoint);
    }
}