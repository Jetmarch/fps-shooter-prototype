using System;
using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [Serializable]
    public sealed class BasePriceFormula : TableFormula
    {
        [SerializeField] private int _someCoefficient = 2;
        public override int CalculateValue(int baseValue, int level)
        {
            if (_someCoefficient == 0) return 0;
            
            return baseValue * (level * level) / _someCoefficient;
        }
    }
}