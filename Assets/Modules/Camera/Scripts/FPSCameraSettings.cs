using FPSShooter.Modules.Utils;
using UnityEngine;

namespace FPSShooter.Modules.FPSCamera
{
    [CreateAssetMenu(fileName = "FPSCameraSettings", menuName = "FPS Shooter/Camera/FPSCameraSettings")]
    public sealed class FPSCameraSettings : ScriptableObject
    {
        [SerializeField] private float _cameraSensitivity = 1f;
        [SerializeField] private float _cameraMaxVerticalAngle = 90f;
        [SerializeField] private float _cameraMinVerticalAngle = -90f;
        
        [SerializeField] private SpringMotionSettings _springMotionSettings;
        
        public float CameraSensitivity => _cameraSensitivity;
        public float CameraMaxVerticalAngle => _cameraMaxVerticalAngle;
        public float CameraMinVerticalAngle => _cameraMinVerticalAngle;
        public SpringMotionSettings SpringMotionSettings => _springMotionSettings;
    }
}