using System;
using UnityEngine;

namespace FPSShooter.Gameplay.ImpactSystem
{
    public struct Impact 
    {
        public readonly int HealthDelta;
        public readonly float ImpulseForce;
        public readonly Vector3 ImpulseVector;

        public Impact(int healthDelta, float impulseForce, Vector3 impulseVector)
        {
            HealthDelta = healthDelta;
            ImpulseForce = impulseForce;
            ImpulseVector = impulseVector;
        }
    }

    public static class ImpactUseCases
    {
        public static void AffectTarget(GameObject target, GameObject affector, Impact impact)
        {
            if (!target.TryGetComponent<ObjectStateComponent>(out var objectState))
            {
                Debug.LogWarning("Target object cannot be affected by impact");
                return;
            }
            
            objectState.Affect(impact);
        }
    }
}
