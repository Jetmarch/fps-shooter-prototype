using FPSShooter.Core.Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    public sealed class ObjectStateComponent : SerializedMonoBehaviour
    {
        [SerializeField] private ObjectState _objectState;
        [SerializeField] private ParticleType _hitParticle;
        
        [SerializeField] private IParticlesManager _particlesManager;

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