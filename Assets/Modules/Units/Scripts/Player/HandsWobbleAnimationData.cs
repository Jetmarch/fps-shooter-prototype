using System;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    [Serializable]
    public sealed class HandsWobbleAnimationData
    {
        [SerializeField] private float _wobbleSpeed = 1;
        [SerializeField] private float _positionWobbleStrength = 0.1f;
        [SerializeField] private float _rotationWobbleStrength = 0.5f;
        [SerializeField] private float _wobbleSmoothness = 5f;
        
        public float WobbleSpeed => _wobbleSpeed;
        public float PositionWobbleStrength => _positionWobbleStrength;
        public float RotationWobbleStrength => _rotationWobbleStrength;
        public float WobbleSmoothness => _wobbleSmoothness;
    }
}