using System.Collections.Generic;
using FPSShooter.Modules.Utils;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace FPSShooter.Core.Managers
{
    public sealed class ParticlesManager : SerializedMonoBehaviour, IParticlesManager
    {
        [OdinSerialize] private Dictionary<ParticleType, GameObjectPool> _particlePools;

        private void Awake()
        {
            foreach (var particlePool in _particlePools.Values)
            {
                particlePool.Initialize();
            }
        }

        public void SpawnParticles(ParticleType particleType, Vector3 position, Quaternion rotation)
        {
            if (!_particlePools.TryGetValue(particleType, out GameObjectPool pool))
            {
                throw new KeyNotFoundException("No particle pool found for particle type: " + particleType);
            }
            
            var particle = pool.GetObject();
            particle.transform.position = position;
            particle.transform.rotation = rotation;

        }
    }

    public enum ParticleType
    {
        BulletImpact,
        MetalImpact,
        BloodImpact,
        LittleExplosionImpact
    }
}