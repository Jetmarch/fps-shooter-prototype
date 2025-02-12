using FPSShooter.Gameplay.FPSCamera;
using UnityEngine;

namespace FPSShooter.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HandsFollowCameraLook
    {
        private readonly Transform _hands;
        private readonly float _handsFollowSpeed;
        private readonly  FPSCameraController _fpsCamera;

        public HandsFollowCameraLook(Transform hands, float handsFollowSpeed, FPSCameraController fpsCamera)
        {
            _hands = hands;
            _handsFollowSpeed = handsFollowSpeed;
            _fpsCamera = fpsCamera;
        }
        
        public void Update(float deltaTime)
        {
            _hands.rotation = Quaternion.Slerp(_hands.rotation, _fpsCamera.Rotation, deltaTime * _handsFollowSpeed);
        }
    }
}