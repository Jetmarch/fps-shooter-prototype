using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public interface IProjectilePresenter
    {
        void Initialize();
        void Update(float deltaTime);
        void Hit(GameObject target, Vector3 hitPoint, Vector3 hitNormal);
        ProjectileType GetProjectileType();
    }

    
}