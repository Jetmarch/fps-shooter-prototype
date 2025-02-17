using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public interface IProjectileManager
    {
        ProjectileView CreateProjectile(ProjectileType type, Transform shootPoint);
    }
}