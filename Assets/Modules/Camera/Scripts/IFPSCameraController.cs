using UnityEngine;

namespace FPSShooter.Modules.FPSCamera
{
    public interface IFPSCameraController
    {
        Quaternion Rotation { get; }
        void Look(Vector2 lookVector);
    }
}