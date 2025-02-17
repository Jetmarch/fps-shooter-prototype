using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace FPSShooter.Modules.Units
{
    [Serializable]
    public sealed class WeaponSwayEffect
    {
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private WeaponSwayEffectData _data;
        
        private Vector2 _mousePosition;

        public WeaponSwayEffect(Transform weaponHolder, WeaponSwayEffectData data)
        {
            _weaponHolder = weaponHolder;
            _data = data;
        }

        public void UpdateInput(Vector2 mousePosition)
        {
            _mousePosition = mousePosition;
        }
        
        public void Update(float deltaTime)
        {
            var rotationX = Quaternion.AngleAxis(-_mousePosition.y * _data.SwayMultiplier, Vector3.right);
            var rotationY = Quaternion.AngleAxis(_mousePosition.x * _data.SwayMultiplier, Vector3.up);
            
            var targetRotation = rotationX * rotationY;
            
            _weaponHolder.localRotation = Quaternion.Slerp(_weaponHolder.localRotation, targetRotation, _data.Smooth * deltaTime);
        }
    }

    [Serializable]
    public sealed class WeaponSwayEffectData
    {
        [SerializeField] private float _smooth = 8;
        [SerializeField] private float _swayMultiplier = 2;
        
        public float Smooth => _smooth;
        public float SwayMultiplier => _swayMultiplier;
    }
}