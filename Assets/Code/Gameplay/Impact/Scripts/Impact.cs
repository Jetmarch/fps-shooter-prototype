using UnityEngine;

namespace FPSShooter.Gameplay.Impact
{
    public struct Impact 
    {
        public readonly int HealthDelta;
        public readonly float Impulse;
        public readonly Vector3 ImpulseVector;

        public Impact(int healthDelta, float impulse, Vector3 impulseVector)
        {
            HealthDelta = healthDelta;
            Impulse = impulse;
            ImpulseVector = impulseVector;
        }
    }

    public static class ImpactUseCases
    {
        public static void AffectTarget(GameObject target, GameObject affector, Impact impact)
        {
            if (!target.TryGetComponent<ObjectStateComponent>(out var objectState)) return;
            
            objectState.Affect(impact);
        }
    }
}
