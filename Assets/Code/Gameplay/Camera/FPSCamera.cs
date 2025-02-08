using System;
using UnityEngine;

namespace FPSShooter.Gameplay.FPSCamera
{
    [Serializable]
    public sealed class FPSCameraController
    {
        public Quaternion Rotation => _camera.transform.rotation;
        private readonly Camera _camera;
        private readonly FPSCameraSettings _settings;
        
        private float _xRotation;
        private float _yRotation;

        public FPSCameraController(FPSCameraSettings settings, Camera camera)
        {
            _settings = settings;
            _camera = camera;
        }

        public void Look(Vector2 lookVector)
        {
            _yRotation += lookVector.x;
            _xRotation += -lookVector.y;
            _xRotation = Mathf.Clamp(_xRotation, _settings.CameraMinVerticalAngle, _settings.CameraMaxVerticalAngle);
            var lookRotation = new Vector3(_xRotation, _yRotation) * _settings.CameraSensitivity;
            _camera.transform.eulerAngles = lookRotation;
        }
    }
}
