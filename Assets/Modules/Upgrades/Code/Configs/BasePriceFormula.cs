using System;
using UnityEngine;

namespace FPSShooter.Modules.Meta.Upgrades
{
    [Serializable]
    public sealed class BasePriceFormula : TableFormula
    {
        [SerializeField] private int _someCoefficient = 2;
        public override float CalculateValue(int baseValue, int level)
        {
            if (_someCoefficient == 0) return 0;
            
            return (float)baseValue * (level * level) / _someCoefficient;
        }
    }
}