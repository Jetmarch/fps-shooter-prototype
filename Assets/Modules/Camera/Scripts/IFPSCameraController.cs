using UnityEngine;

namespace FPSShooter.Modules.FPSCamera
{
    public interface IFPSCameraController
    {
        Quaternion Rotation { get; }
        void Look(Vector2 lookVector);
        void SetPosition(Vector3 position);
        void SetRotation(Vector3 rotation);
    }
}