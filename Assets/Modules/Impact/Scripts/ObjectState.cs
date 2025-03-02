using System;
using FPSShooter.Core.Utils;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    [Serializable]
    public sealed class ObjectState
    {
        public bool IsDead
        {
            get => _isDead;
            set => _isDead = value;
        }

        public int CurrentHealth
        {
            get => _health.CurrentValue;
            set => _health.CurrentValue = value;
        }

        public bool IsInvincible
        {
            get => _isInvincible;
            set => _isInvincible = value;
        }
        public int MaxHealth => _health.MaxValue;
        public int MinHealth => _health.MinValue;
        
        [SerializeField] private ClampedIntValue _health;
        [SerializeField] private bool _isDead;
        [SerializeField] private bool _isInvincible;

        public void Reset()
        {
            _health.Reset();
            _isDead = false;
        }
    }
}