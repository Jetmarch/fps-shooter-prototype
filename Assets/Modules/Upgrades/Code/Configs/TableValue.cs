using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [Serializable]
    public sealed class TableValue
    {
        [ShowInInspector] private TableFormula _formula;
        [SerializeField] private int _baseValue = 1;

        [ReadOnly, SerializeField]
        private int[] _values;
        public void FillLevelPrices(int maxLevel)
        {
            if (_formula == null) return;
            
            _values = new int[maxLevel];
            for (int i = 0; i < maxLevel; i++)
            {
                _values[i] = _formula.CalculateValue(_baseValue, i + 1);
            }
        }

        public int GetValue(int level)
        {
            var index = level - 1;
            index = Mathf.Clamp(index, 0, _values.Length - 1);
            return _values[index];
        }
    }
}