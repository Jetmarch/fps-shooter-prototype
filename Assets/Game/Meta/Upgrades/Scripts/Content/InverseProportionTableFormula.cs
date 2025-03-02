using System;
using FPSShooter.Modules.Meta.Upgrades;

namespace FPSShooter.Game.Meta.Upgrades
{
    [Serializable]
    public sealed class InverseProportionTableFormula : TableFormula
    {
        public override float CalculateValue(int baseValue, int level)
        {
            return (float)1 / (baseValue + level + 1);
        }
    }
}