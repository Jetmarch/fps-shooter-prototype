using UnityEngine;

namespace FPSShooter.Modules.Gameplay.Impact
{
    public static class ImpactUseCases
    {
        public static void AffectTarget(GameObject target, GameObject affector, Impact impact)
        {
            if (!target.TryGetComponent<IAffectableObject>(out var objectState))
            {
                Debug.LogWarning("Target object cannot be affected by impact");
                return;
            }
            
            objectState.Affect(impact);
        }
    }
}