using System;
using FPSShooter.Core.Managers;
using FPSShooter.Gameplay.Utils;
using UnityEngine;
using VContainer;

namespace FPSShooter.Gameplay.Projectiles
{
    public sealed class ProjectileManager : MonoBehaviour, IProjectileManager
    {
        [SerializeField] private GameObjectPool _projectilePool;
        [SerializeField] private GameLoopManager _gameLoopManager;

        [Inject]
        private void Configure(GameLoopManager gameLoopManager)
        {
            _gameLoopManager = gameLoopManager;
        }
        
        private void Start()
        {
            _projectilePool.Initialize();
        }

        public Projectile CreateProjectile(Transform shootPoint)
        {
            //TODO: projectile factory
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
            projectile.transform.position = shootPoint.position;
            projectile.transform.rotation = shootPoint.rotation;
            projectile.OnProjectileDestroyed += ReturnProjectile;
            _gameLoopManager.AddListener(projectile);
            return projectile;
        }

        private void ReturnProjectile(Projectile projectile)
        {
            _gameLoopManager.RemoveListener(projectile);
            _projectilePool.ReturnObject(projectile.gameObject);
        }
    }
}