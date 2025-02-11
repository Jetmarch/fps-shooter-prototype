using System;
using FPSShooter.Gameplay.Utils;
using UnityEngine;

namespace FPSShooter.Gameplay.Projectiles
{
    public sealed class ProjectileManager : MonoBehaviour, IProjectileManager
    {
        [SerializeField] private GameObjectPool _projectilePool;
        
        private void Start()
        {
            _projectilePool.Initialize();
        }

        public Projectile GetProjectile()
        {
            var projectileObject = _projectilePool.GetObject();
            if (!projectileObject)
            {
                throw new Exception("Projectile from projectilePool could not be retrieved");
            }
            
            var projectile = projectileObject.GetComponent<Projectile>();
            if (!projectile)
            {
                throw new MissingComponentException("Projectile object is missing a Projectile component.");
            }
            
            //projectile.OnDestroy += ReturnProjectile;
            return projectile;
        }

        public void ReturnProjectile(Projectile projectile)
        {
            _projectilePool.ReturnObject(projectile.gameObject);
        }
    }
}