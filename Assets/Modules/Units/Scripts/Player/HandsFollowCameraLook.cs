using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.FPSCamera;
using UnityEngine;

namespace FPSShooter.Modules.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HandsFollowCameraLook : ILateUpdateListener
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

        public void OnLateUpdate(float deltaTime)
        {
            _hands.rotation = _fpsCamera.Rotation;
        }
    }
}