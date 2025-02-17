using System;
using UnityEngine;

namespace FPSShooter.Gameplay.ImpactSystem
{
    public struct Impact 
    {
        public readonly int HealthDelta;
        public readonly float ImpulseForce;
        public readonly Vector3 ImpulseVector;
        public readonly Vector3 HitPoint;
        public readonly Quaternion HitRotation;

        public Impact(int healthDelta, float impulseForce, Vector3 impulseVector, Vector3 hitPoint, Quaternion hitRotation)
        {
            HealthDelta = healthDelta;
            ImpulseForce = impulseForce;
            ImpulseVector = impulseVector;
            HitPoint = hitPoint;
            HitRotation = hitRotation;
        }
    }
}
