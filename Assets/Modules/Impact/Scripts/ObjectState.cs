using System;
using FPSShooter.Core.Utils;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    [Serializable]
    public sealed class ObjectState
    {
        public event Action OnHealthChanged;
        public event Action OnObjectDestroyed;
        [SerializeField] private ClampedIntValue _health;
        [SerializeField] private bool _isDead;

        public void Initialize()
        {
            _health.Reset();
            _isDead = false;
        }
        
        public void Affect(Impact impact)
        {
            if (_isDead) return;
            _health.CurrentValue += impact.HealthDelta;
            OnHealthChanged?.Invoke();

            if (_health.CurrentValue <= _health.MinValue)
            {
                OnObjectDestroyed?.Invoke();
                _isDead = true;
            }
        }
    }
}