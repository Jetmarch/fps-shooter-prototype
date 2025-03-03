using System;
using FPSShooter.Core.Managers;
using UnityEngine;
using VContainer.Unity;

namespace FPSShooter.Game.Gameplay.Projectiles
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DestroyParticlesController : IInitializable, IDisposable
    {
        private readonly IParticlesManager _particlesManager;
        private readonly ProjectileDestroyMechanic _projectileDestroyMechanic;
        private readonly string _particleType;
        
        public void Initialize()
        {
            _projectileDestroyMechanic.NotifyProjectileDestroyed += SpawnParticles;
        }

        public void Dispose()
        {
            _projectileDestroyMechanic.NotifyProjectileDestroyed -= SpawnParticles;
        }

        private void SpawnParticles(GameObject gameObject)
        {
            _particlesManager.SpawnParticles(_particleType, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}