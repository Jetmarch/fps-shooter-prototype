using System;
using System.Collections.Generic;
using FPSShooter.Game.Gameplay.Projectiles;
using FPSShooter.Modules.Units;
using FPSShooter.Modules.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Projectiles
{
    public sealed class ProjectileManager : SerializedMonoBehaviour, IProjectileManager
    {
        public event Action<GameObject> OnProjectileHitObject;
        
        [OdinSerialize] private Dictionary<ProjectileType, GameObjectPool> _projectilePools;
        
        private void Awake()
        {
            foreach (var projectilePool in _projectilePools.Values)
            {
                projectilePool.Initialize();
            }
        }

        public GameObject CreateProjectile(ProjectileType type, Transform shootPoint)
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
            
            var projectile = projectileObject.GetComponent<UnitView>();
            if (!projectile)
            {
                throw new MissingComponentException("Projectile object is missing a UnitView component.");
            }
            
            projectile.transform.position = shootPoint.position;
            projectile.transform.rotation = shootPoint.rotation;
            var destroyMechanic = projectile.GetMechanic<ProjectileDestroyMechanic>();
            if (destroyMechanic == null)
            {
                throw new MissingComponentException("Projectile object is missing a DestroyMechanic component.");
            }

            destroyMechanic.NotifyProjectileDestroyed += ReturnProjectile;
            
            var affectTargetMechanic = projectile.GetMechanic<IAffectTargetMechanic>();
            if (affectTargetMechanic == null)
            {
                throw new MissingComponentException("Projectile object is missing a AffectTargetMechanic component.");
            }

            affectTargetMechanic.NotifyAffectTarget += ProjectileOnHitObject;
            
            var ballisticMoveMechanic = projectile.GetMechanic<BallisticMoveMechanic>();
            if (ballisticMoveMechanic == null)
            {
                throw new MissingComponentException("Projectile object is missing a BallisticMoveMechanic component.");
            }
            
            ballisticMoveMechanic.Initialize();
            
            return projectile.gameObject;
        }

        private void ProjectileOnHitObject(GameObject obj)
        {
            OnProjectileHitObject?.Invoke(obj);
        }

        private void ReturnProjectile(GameObject projectile)
        {
            var unitView = projectile.GetComponent<UnitView>();
            if (unitView == null)
            {
                throw new MissingComponentException("Projectile object is missing a UnitView component.");
            }
            
            var projectileMechanic = unitView.GetMechanic<ProjectileMechanic>();
            if (projectileMechanic == null)
            {
                throw new MissingComponentException("Projectile object is missing a ProjectileMechanic component.");
            }
            
            if (!_projectilePools.TryGetValue(projectileMechanic.ProjectileType, out var pool))
            {
                throw new Exception($"Projectile pool for {projectileMechanic.ProjectileType} could not be retrieved");
            }

            var destroyMechanic = unitView.GetMechanic<ProjectileDestroyMechanic>();
            if (destroyMechanic == null)
            {
                throw new MissingComponentException("Projectile object is missing a DestroyMechanic component.");
            }
            destroyMechanic.NotifyProjectileDestroyed -= ReturnProjectile;

            var affectTargetMechanic = unitView.GetMechanic<IAffectTargetMechanic>();
            if (affectTargetMechanic == null)
            {
                throw new MissingComponentException("Projectile object is missing a AffectTargetMechanic component.");
            }
            
            affectTargetMechanic.NotifyAffectTarget -= ReturnProjectile;
            
            pool.ReturnObject(projectile.gameObject);
        }
    }

    //TODO:
    public sealed class ProjectileFactory
    {
        
    }
}