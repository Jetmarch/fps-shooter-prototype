using System;
using UnityEngine;

namespace FPSShooter.Core.Utils
{
    [Serializable]
    public sealed class ClampedIntValue
    {
        [SerializeField] private int _maxValue;
        [SerializeField] private int _minValue;
        [SerializeField] private int _currentValue;

        public ClampedIntValue(int minValue, int maxValue, int currentValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _currentValue = currentValue;
        }

        public ClampedIntValue(ClampedIntValue clampedIntValue)
        {
            _minValue = clampedIntValue.MinValue;
            _maxValue = clampedIntValue.MaxValue;
            _currentValue = clampedIntValue.CurrentValue;
        }

        public void Reset()
        {
            _currentValue = _maxValue;
        }

        public int MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }
        public int MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        public int CurrentValue
        {
            get => _currentValue;
            set => _currentValue = Mathf.Clamp(value, _minValue, _maxValue);
        }
    }
}