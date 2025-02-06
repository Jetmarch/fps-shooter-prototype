using System;
using KinematicCharacterController;
using UnityEngine;

namespace FPSShooter.Gameplay
{
    [Serializable]
    public sealed class MovementControllerData
    {
        public KinematicCharacterMotor Motor;
        public Transform CameraTarget;
        public Transform Root;
        public float WalkSpeed = 20f;
        public float CrouchSpeed = 7f;
        public float WalkResponce = 25f;
        public float CrouchResponce = 25f;
    }
}