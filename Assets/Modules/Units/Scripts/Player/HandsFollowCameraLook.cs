using FPSShooter.Modules.FPSCamera;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HandsFollowCameraLook
    {
        private readonly Transform _hands;
        private readonly HandsFollowCameraLookData _data;
        private readonly IFPSCameraController _fpsCamera;

        public HandsFollowCameraLook(Transform hands, HandsFollowCameraLookData data, IFPSCameraController fpsCamera)
        {
            _hands = hands;
            _data = data;
            _fpsCamera = fpsCamera;
        }
        
        public void Update(float deltaTime)
        {
            var desiredRotation = Quaternion.Slerp(_hands.rotation, _fpsCamera.Rotation, 1f - Mathf.Exp(-_data.HandsFollowSpeed * deltaTime));
            // desiredRotation = _fpsCamera.Rotation;
            _hands.rotation = desiredRotation;
        }
    }
}