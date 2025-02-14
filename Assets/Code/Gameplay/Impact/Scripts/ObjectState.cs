using System;
using UnityEngine;

namespace FPSShooter.Gameplay.Impact
{
    public sealed class ObjectStateComponent : MonoBehaviour
    {
        [SerializeField] private ObjectState _objectState;
        
        public void Affect(Impact impact)
        {
            _objectState.Affect(impact);
        }
    }
    
    [Serializable]
    public sealed class ObjectState
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _minHealth = 0;
        [SerializeField] private int _currentHealth;
        public void Affect(Impact impact)
        {
            _currentHealth += impact.HealthDelta;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        }
    }
}