using System;
using FPSShooter.Core.Utils;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    [Serializable]
    public sealed class ObjectState
    {
        public event Action<ImpactData> OnHealthChanged;
        public event Action OnObjectDestroyed;
        
        public bool IsDead => _isDead;
        
        public int CurrentHealth => _health.CurrentValue;
        public int MaxHealth => _health.MaxValue;
        [SerializeField] private ClampedIntValue _health;
        [SerializeField] private bool _isDead;

        public void Initialize()
        {
            _health.Reset();
            _isDead = false;
        }
        
        public void Affect(ImpactData impactData)
        {
            if (_isDead) return;
            _health.CurrentValue += impactData.HealthDelta;
            OnHealthChanged?.Invoke(impactData);

            if (_health.CurrentValue <= _health.MinValue)
            {
                OnObjectDestroyed?.Invoke();
                _isDead = true;
            }
        }
    }
}