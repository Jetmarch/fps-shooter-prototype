using System;
using FPSShooter.Modules.Core.GameLoop;
using FPSShooter.Modules.Utils;
using UnityEngine;

namespace FPSShooter.Modules.FPSCamera
{
    [Serializable]
    public sealed class FPSCameraController : IFPSCameraController, ILateUpdateListener
    {
        public Quaternion Rotation => _camera.transform.rotation;
        private readonly Camera _camera;
        private readonly FPSCameraSettings _settings;
        private readonly SpringMotion _springMotion;

        private bool _isEnabled;
        
        private float _xRotation;
        private float _yRotation;

        private Vector3 _lookRotation;

        public FPSCameraController(FPSCameraSettings settings, Camera camera, Transform cameraTarget)
        {
            _settings = settings;
            _camera = camera;
            _springMotion = new SpringMotion(cameraTarget, _camera.transform, _settings.SpringMotionSettings);
            _isEnabled = true;
        }

        public void Look(Vector2 lookVector)
        {
            if (!_isEnabled) return;
            
            _yRotation += lookVector.x;
            _xRotation += -lookVector.y;
            _xRotation = Mathf.Clamp(_xRotation, _settings.CameraMinVerticalAngle, _settings.CameraMaxVerticalAngle);
            _lookRotation = new Vector3(_xRotation, _yRotation) * _settings.CameraSensitivity;
        }

        public void OnLateUpdate(float deltaTime)
        {
            if (!_isEnabled) return;
            
            _camera.transform.rotation = Quaternion.Euler(_lookRotation);
            _springMotion.UpdateSpring(deltaTime, _camera.transform.up);
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}
