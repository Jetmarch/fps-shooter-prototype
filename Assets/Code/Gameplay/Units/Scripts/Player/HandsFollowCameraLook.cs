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
            _hands.rotation = Quaternion.Slerp(_hands.rotation, _fpsCamera.Rotation, deltaTime * _data.HandsFollowSpeed);
        }
    }

    [Serializable]
    public sealed class HandsFollowCameraLookData
    {
        [SerializeField] private float _handsFollowSpeed = 25;
        public float HandsFollowSpeed => _handsFollowSpeed;
    }
}