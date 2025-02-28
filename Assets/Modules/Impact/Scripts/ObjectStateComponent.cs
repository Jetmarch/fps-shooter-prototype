using FPSShooter.Core.Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    public sealed class ObjectStateComponent : SerializedMonoBehaviour
    {
        [SerializeField] private ObjectState _objectState;
        [SerializeField] private string _hitParticle;
        
        [SerializeField] private IParticlesManager _particlesManager;

        private void Start()
        {
            _objectState.Initialize();
        }

        public void Affect(ImpactData impactData)
        {
            _objectState.Affect(impactData);
            _particlesManager?.SpawnParticles(_hitParticle, impactData.HitPoint, impactData.HitRotation);
        }
    }
}