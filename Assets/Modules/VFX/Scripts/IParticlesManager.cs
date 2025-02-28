using UnityEngine;

namespace FPSShooter.Core.Managers
{
    public interface IParticlesManager
    {
        void SpawnParticles(string particleType, Vector3 position, Quaternion rotation);
    }
}