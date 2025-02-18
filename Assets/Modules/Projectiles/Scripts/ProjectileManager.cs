using System;
using System.Collections.Generic;
using FPSShooter.Modules.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public sealed class ProjectileManager : SerializedMonoBehaviour, IProjectileManager
    {
        [OdinSerialize] private Dictionary<ProjectileType, GameObjectPool> _projectilePools;
        
        private void Awake()
        {
            foreach (var projectilePool in _projectilePools.Values)
            {
                projectilePool.Initialize();
            }
        }

        public ProjectileView CreateProjectile(ProjectileType type, Transform shootPoint)
        {
            //TODO: projectile factory
            if (!_projectilePools.TryGetValue(type, out var pool))
            {
                throw new KeyNotFoundException($"Projectile pool for {type} could not be retrieved");
            }
            
            var projectileObject = pool.GetObject();
            if (!projectileObject)
            {
                throw new Exception("Projectile from projectilePool could not be retrieved");
            }
            
            var projectile = projectileObject.GetComponent<ProjectileView>();
            if (!projectile)
            {
                throw new MissingComponentException("Projectile object is missing a Projectile component.");
            }
            
            projectile.transform.position = shootPoint.position;
            projectile.transform.rotation = shootPoint.rotation;
            projectile.OnProjectileDestroyed += ReturnProjectile;
            projectile.Initialize();
            return projectile;
        }

        private void ReturnProjectile(ProjectileView projectileView)
        {
            if (!_projectilePools.TryGetValue(projectileView.ProjectileType, out var pool))
            {
                throw new Exception($"Projectile pool for {projectileView.ProjectileType} could not be retrieved");
            }
            pool.ReturnObject(projectileView.gameObject);
        }
    }
}