using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public interface IProjectileManager
    {
        ProjectileView CreateProjectile(ProjectileType type, Transform shootPoint);
    }
}