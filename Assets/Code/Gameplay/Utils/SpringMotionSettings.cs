using System;
using UnityEngine;

namespace FPSShooter.Gameplay.Utils
{
    [Serializable]
    public sealed class SpringMotionSettings
    {
        [Space]
        [SerializeField, Min(0.01f)] private float _halfLife = 0.075f;
        [Space]
        [SerializeField] private float _frequency = 18f;
        [Space]
        [SerializeField] private float _angularDisplacement = 2f;
        [SerializeField] private float _linearDisplacement = 0.05f;
        
        public float HalfLife => _halfLife;
        public float Frequency => _frequency;
        public float AngularDisplacement => _angularDisplacement;
        public float LinearDisplacement => _linearDisplacement;
    }
}