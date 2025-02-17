using System;
using UnityEngine;

namespace FPSShooter.Core.Utils
{
    [Serializable]
    public sealed class ClampedFloatValue
    {
        [SerializeField] private float _maxValue;
        [SerializeField] private float _minValue;
        [SerializeField] private float _currentValue;

        public ClampedFloatValue(float maxValue, float minValue, float currentValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;
            _currentValue = currentValue;
        }

        public ClampedFloatValue(ClampedFloatValue clampedFloatValue)
        {
            _maxValue = clampedFloatValue.MaxValue;
            _minValue = clampedFloatValue.MinValue;
            _currentValue = clampedFloatValue.CurrentValue;
        }

        public float MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }
        public float MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        public float CurrentValue
        {
            get => _currentValue;
            set => _currentValue = Mathf.Clamp(value, _minValue, _maxValue);
        }
    }
}