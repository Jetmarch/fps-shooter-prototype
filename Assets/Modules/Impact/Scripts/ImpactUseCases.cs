using FPSShooter.Modules.Units;
using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    public static class ImpactUseCases
    {
        public static void AffectTarget(GameObject target, GameObject affector, ImpactData impactData)
        {
            if (!target.TryGetComponent<UnitView>(out var unitView))
            {
                return;
            }

            var affectMechanics = unitView.GetMechanic<ImpactAffectMechanic>();
            if (affectMechanics == null) return;
            
            affectMechanics.Affect(affector, impactData);
        }
    }
}