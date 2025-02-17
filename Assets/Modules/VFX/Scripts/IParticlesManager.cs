using UnityEngine;

namespace FPSShooter.Core.Managers
{
    public interface IParticlesManager
    {
        void SpawnParticles(ParticleType particleType, Vector3 position, Quaternion rotation);
    }
}