using System;
using FPSShooter.Modules.Core.GameLoop;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    [Serializable]
    public sealed class WeaponSwayEffect : ILateUpdateListener
    {
        [SerializeField] private Transform _weaponHolder;
        [SerializeField] private WeaponSwayEffectData _data;
        
        private Vector2 _mousePosition;

        public WeaponSwayEffect(Transform weaponHolder, WeaponSwayEffectData data)
        {
            _weaponHolder = weaponHolder;
            _data = data;
        }

        public void OnLook(Vector2 mousePosition)
        {
            _mousePosition = mousePosition;
        }
        
        public void SwayEffect(float deltaTime)
        {
            var rotationX = Quaternion.AngleAxis(-_mousePosition.y * _data.SwayMultiplier, Vector3.right);
            var rotationY = Quaternion.AngleAxis(_mousePosition.x * _data.SwayMultiplier, Vector3.up);
            
            var targetRotation = rotationX * rotationY;
            
            _weaponHolder.localRotation = Quaternion.Slerp(_weaponHolder.localRotation, targetRotation, _data.Smooth * deltaTime);
        }

        public void OnLateUpdate(float deltaTime)
        {
            SwayEffect(deltaTime);
        }
    }
}