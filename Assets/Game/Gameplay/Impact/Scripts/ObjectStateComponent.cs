using FPSShooter.Core.Managers;
using UnityEngine;

namespace FPSShooter.Gameplay.ImpactSystem
{
    public sealed class ObjectStateComponent : MonoBehaviour
    {
        [SerializeField] private ObjectState _objectState;
        [SerializeField] private ParticleType _hitParticle;
        
        [SerializeField] private ParticlesManager _particlesManager;

        private void Start()
        {
            _objectState.Initialize();
        }

        public void Affect(Impact impact)
        {
            _objectState.Affect(impact);
            _particlesManager?.SpawnParticles(_hitParticle, impact.HitPoint, impact.HitRotation);
        }
    }
}