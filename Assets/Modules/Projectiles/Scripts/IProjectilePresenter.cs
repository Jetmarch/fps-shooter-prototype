using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public interface IProjectilePresenter
    {
        void Initialize();
        void Hit(Collision other);
        
        ProjectileType GetProjectileType();
    }

    
}