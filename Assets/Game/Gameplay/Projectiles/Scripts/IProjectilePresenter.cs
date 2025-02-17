using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public interface IProjectilePresenter
    {
        void Initialize();
        void Update(float deltaTime);
        void Hit(GameObject target, Vector3 hitPoint);
        ProjectileType GetProjectileType();
    }

    
}