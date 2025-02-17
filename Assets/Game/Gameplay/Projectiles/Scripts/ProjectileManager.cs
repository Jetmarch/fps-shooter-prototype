using System;
using System.Collections.Generic;
using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Projectiles
{
    public sealed class ProjectileManager : SerializedMonoBehaviour, IProjectileManager
    {
        [OdinSerialize] private Dictionary<ProjectileType, GameObjectPool> _projectilePools;
        private GameLoopManager _gameLoopManager;
        
        [Inject]
        private void Configure(GameLoopManager gameLoopManager)
        {
            _gameLoopManager = gameLoopManager;
        }
        
        private void Start()
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
                throw new Exception($"Projectile pool for {type} could not be retrieved");
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
            _gameLoopManager.AddListener(projectile);
            return projectile;
        }

        private void ReturnProjectile(ProjectileView projectileView)
        {
            _gameLoopManager.RemoveListener(projectileView);
            if (!_projectilePools.TryGetValue(projectileView.ProjectileType, out var pool))
            {
                throw new Exception($"Projectile pool for {projectileView.ProjectileType} could not be retrieved");
            }
            pool.ReturnObject(projectileView.gameObject);
        }
    }
}