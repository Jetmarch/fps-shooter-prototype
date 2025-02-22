using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.FPSCamera;
using UnityEngine;

namespace FPSShooter.Game.Gameplay.Units
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class HandsFollowCameraLook : ILateUpdateListener
    {
        private readonly Transform _hands;
        private readonly IFPSCameraController _fpsCamera;

        public HandsFollowCameraLook(Transform hands, IFPSCameraController fpsCamera)
        {
            _hands = hands;
            _fpsCamera = fpsCamera;
        }

        public void OnLateUpdate(float deltaTime)
        {
            _hands.rotation = _fpsCamera.Rotation;
        }
    }
}