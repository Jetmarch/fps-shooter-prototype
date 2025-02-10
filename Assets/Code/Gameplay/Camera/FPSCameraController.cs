using System;
using FPSShooter.Gameplay.Utils;
using UnityEngine;

namespace FPSShooter.Gameplay.FPSCamera
{
    [Serializable]
    public sealed class FPSCameraController 
    {
        public Quaternion Rotation => _camera.transform.rotation;
        private readonly Camera _camera;
        private readonly FPSCameraSettings _settings;
        private readonly SpringMotion _springMotion;
        
        private float _xRotation;
        private float _yRotation;

        private Vector3 _lookRotation;

        public FPSCameraController(FPSCameraSettings settings, Camera camera, Transform cameraTarget)
        {
            _settings = settings;
            _camera = camera;
            _springMotion = new SpringMotion(cameraTarget, _camera.transform, _settings.SpringMotionSettings);
        }

        public void Look(Vector2 lookVector)
        {
            _yRotation += lookVector.x;
            _xRotation += -lookVector.y;
            _xRotation = Mathf.Clamp(_xRotation, _settings.CameraMinVerticalAngle, _settings.CameraMaxVerticalAngle);
            _lookRotation = new Vector3(_xRotation, _yRotation) * _settings.CameraSensitivity;
        }

        public void OnLateUpdate(float deltaTime)
        {
            _camera.transform.eulerAngles = _lookRotation;
            _springMotion.UpdateSpring(deltaTime, _camera.transform.up);
        }
    }
}
