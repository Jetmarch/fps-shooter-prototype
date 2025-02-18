using System;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    [Serializable]
    public sealed class WeaponSwayEffectData
    {
        [SerializeField] private float _smooth = 8;
        [SerializeField] private float _swayMultiplier = 2;
        
        public float Smooth => _smooth;
        public float SwayMultiplier => _swayMultiplier;
    }
}