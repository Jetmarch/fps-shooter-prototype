using System;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    [Serializable]
    public sealed class ObjectState
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _minHealth = 0;
        [SerializeField] private int _currentHealth;

        public void Initialize()
        {
            _currentHealth = _maxHealth;
        }
        
        public void Affect(Impact impact)
        {
            _currentHealth += impact.HealthDelta;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        }
    }
}