using System;
using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class ImpactAffectMechanic : IUnitMechanic
    {
        public event Action<GameObject, ImpactData> OnImpact;
        
        public void Affect(GameObject affector, ImpactData impact)
        {
            OnImpact?.Invoke(affector, impact);
        }
    }
}