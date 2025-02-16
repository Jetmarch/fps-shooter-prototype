using System;
using FPSShooter.Gameplay.FPSCamera;
using UnityEngine;

namespace FPSShooter.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HandsFollowCameraLook
    {
        private readonly Transform _hands;
        private readonly HandsFollowCameraLookData _data;
        private readonly  FPSCameraController _fpsCamera;

        public HandsFollowCameraLook(Transform hands, HandsFollowCameraLookData data, FPSCameraController fpsCamera)
        {
            _hands = hands;
            _data = data;
            _fpsCamera = fpsCamera;
        }
        
        public void Update(float deltaTime)
        {
            var desiredRotation = Quaternion.Slerp(_hands.rotation, _fpsCamera.Rotation, 1f - Mathf.Exp(-_data.HandsFollowSpeed * deltaTime));
            // desiredRotation.y = _fpsCamera.Rotation.y;
            desiredRotation = _fpsCamera.Rotation;
            _hands.rotation = desiredRotation;
            // _hands.localRotation = Quaternion.Euler(Vector3.zero);
            // _hands.rotation = Quaternion.Euler(Vector3.zero);
            
            // _hands.rotation = Quaternion.RotateTowards(_hands.rotation, _fpsCamera.Rotation, Time.deltaTime * _data.HandsFollowSpeed);
        }
    }

    [Serializable]
    public sealed class HandsFollowCameraLookData
    {
        [SerializeField] private float _handsFollowSpeed = 25;
        public float HandsFollowSpeed => _handsFollowSpeed;
    }
}